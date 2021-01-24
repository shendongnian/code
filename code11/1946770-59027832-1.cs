        private List<T> GetTreeObjects<T>(DependencyObject obj) where T : DependencyObject
        {
            List<T> objects = new List<T>();
            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null)
                {
                    T requestedType = child as T;
                    if (requestedType != null)
                        objects.Add(requestedType);
                    objects.AddRange(this.GetTreeObjects<T>(child));
                }
            }
            return objects;
        }
        /// <summary>
        /// ShowAllExpanders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            List<Expander> expander = GetTreeObjects<Expander>(lvUsers);
            expander.All(a => a.IsExpanded = true);
        }
        /// <summary>
        /// HideAllExpanders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //List<Expander> expander = GetVisualTree<Expander>(ParameterConfigViewList);
            //for (int i = 0; i < expander.Count; i++)
            //{
            //    expander[i].Height = 0;
            //    expander[i].Height = Double.NaN;
            //    expander[i].IsExpanded = false;
            //}
            //List<Expander> expanderss = FindVisualChildren<Expander>(lvUsers).ToList();
            foreach (Expander tb in FindVisualChildren<Expander>(lvUsers))
            {
                tb.Height = 0;
                tb.Height = Double.NaN;
                tb.IsExpanded = false;
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
