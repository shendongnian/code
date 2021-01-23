    public static class FocusManager
    {
        public static bool SetFocus(this IViewAware screen ,Expression<Func<object>> propertyExpression)
        {
            return SetFocus(screen ,PropertyName.For(propertyExpression));
        }
    
        public static bool SetFocus(this IViewAware screen ,string property)
        {
            Contract.Requires(property != null ,"Property cannot be null.");
            var view = screen.GetView() as UserControl;
            if ( view != null )
            {
                var control = FindChild(view ,property);
                bool focus = control != null && control.Focus();
                return focus;
            }
            return false;
        }
    
        private static FrameworkElement FindChild(UIElement parent ,string childName)
        {
            // Confirm parent and childName are valid. 
            if ( parent == null || string.IsNullOrWhiteSpace(childName) ) return null;
    
            FrameworkElement foundChild = null;
    
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
    
            for ( int i = 0; i < childrenCount; i++ )
            {
                FrameworkElement child = VisualTreeHelper.GetChild(parent ,i) as FrameworkElement;
                if ( child != null )
                {
                    BindingExpression bindingExpression = null;
                    var conventions = ConventionManager.GetElementConvention(child.GetType());
                    if ( conventions != null )
                    {
                        var bindablePro = conventions.GetBindableProperty(child);
                        if ( bindablePro != null )
                        {
                            bindingExpression = child.GetBindingExpression(bindablePro);
                        }
                    }
    
                    if ( child.Name == childName )
                    {
                        foundChild = child;
                        break;
                    }
                    if ( bindingExpression != null )
                    {
                        if ( bindingExpression.ResolvedSourcePropertyName == childName )
                        {
                            foundChild = child;
                            break;
                        }
                    }
                    foundChild = FindChild(child ,childName);
                    if ( foundChild != null && foundChild.Name == childName )
                    {
                        break;
                    }
    
                }
            }
    
            return foundChild;
        }
    }
