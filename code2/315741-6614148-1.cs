            private static DependencyObject FindParent(this DependencyObject obj, Predicate<DependencyObject> where)
            {
                var parent = VisualTreeHelper.GetParent(obj);
    
                if (parent == null || where(parent))
                {
                    return parent;
                }
    
                return parent.FindParent(where);
            }
    
            public static T FindParentOfType<T>(this DependencyObject obj) where T : DependencyObject
            {
                return (T) FindParent(obj, x => x is T);
            }
