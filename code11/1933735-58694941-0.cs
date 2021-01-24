            StackPanel sp = (StackPanel)GetDescendantByType(LvMslInfoTable, typeof(StackPanel));
            foreach (var gi in sp.Children.Cast<GroupItem>())
            {
                var tb = (TextBlock)GetDescendantByType(gi, typeof(TextBlock));
                if (tb == null) continue;
                
                Expander exp = (Expander)GetDescendantByType(gi, typeof(Expander));
                if (exp == null) continue;
                if (!expandedStateStatus.ContainsKey(tb.Text))
                {
                    expandedStateStatus.Add(tb.Text, exp.IsExpanded);
                }
            }
        private static Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;
            Visual foundElement = null;
            if (element is FrameworkElement frameworkElement)
            {
                frameworkElement.ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                {
                    break;
                }
            }
            return foundElement;
        }
