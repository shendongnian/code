    protected T FindVisualChild<T>(DependencyObject obj, string name) where T : DependencyObject
                {
                    //get number
                    int count = VisualTreeHelper.GetChildrenCount(obj);
        
                    //Traversing each object based on the index
                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(obj, i);
                        //According to the parameters to determine whether we are looking for the object
                        if (child is T && ((FrameworkElement)child).Name == name)
                        {
                            return (T)child;
                        }
                        else
                        {
                            var child1 = FindVisualChild<T>(child, name);
        
                            if (child1 != null)
                            {
                                return (T)child1;
                            }
        
        
                        }
                    }
        
                    return null;
        
                }
