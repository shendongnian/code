    internal static DependencyPropertyDescriptor FromProperty(DependencyProperty dp, Type tOwner, Type tTarget, bool _)
    {
        /// 1. 'tOwner' must define a true CLR property, as obtained via reflection, 
        /// in order to obtain a normal (i.e. non-attached) DependencyProperty
        if (tOwner.GetProperty(dp.Name) != null)
        {
            DependencyPropertyDescriptor dpd;
    
            var dict = descriptor_cache;
            lock (dict)
                if (dict.TryGetValue(dp, out dpd))
                    return dpd;
    
            dpd = new DependencyPropertyDescriptor(null, dp.Name, tTarget, dp, false);
            lock (dict)
                dict[dp] = dpd;
    
            /// 2. Exiting here means that, if instance properties are defined on tOwner,
            /// you will *never* get the attached property descriptor. Furthermore,
            /// static Get/Set accessors, if any, will be ignored in favor of those instance
            /// accessors, even when calling 'RegisterAttached'
            return dpd;
        }
    
        /// 3. To obtain an attached DependencyProperty, 'tOwner' must define a public,
        /// static 'get' or 'set' accessor (or both).
    
        if ((tOwner.GetMethod("Get" + dp.Name) == null) && (tOwner.GetMethod("Set" + dp.Name) == null))
            return null;
    
        /// 4. If we are able to get a descriptor for the attached property, it is a
        /// DependencyObjectPropertyDescriptor. This type and DependencyPropertyDescriptor
        /// both derive directly from ComponentModel.PropertyDescriptor so they share
        /// no 'is-a' relation.
    
        var dopd = DependencyObjectProvider.GetAttachedPropertyDescriptor(dp, tTarget);
        /// 5. Note: If the this line returns null, FromProperty isn't called below (new C# syntax)
        /// 6. FromProperty() uses the distinction between descriptor types mentioned in (4.)
        /// to configure 'IsAttached' on the returned DependencyProperty, so success here is 
        /// the only way attached property operations can succeed.
        return dopd?.FromProperty(dopd);
    }
