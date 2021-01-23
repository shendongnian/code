        public bool IsAtLeastOneCheckboxChecked(DependencyObject rootObject)
        {
            var checkboxes = FindLogicalChildrenOfType<CheckBox>(rootObject);
            foreach (var checkbox in checkboxes)
            {
                if (checkbox.IsChecked == true)
                {
                    return true;
                }
            }
            return false;
        }
        public static IEnumerable<T> FindLogicalChildrenOfType<T>(DependencyObject rootElement) where T : DependencyObject
        {
            if (rootElement != null)
            {
                var list = new List<DependencyObject>(LogicalTreeHelper.GetChildren(rootElement).OfType<DependencyObject>());
                foreach (var item in list)
                {
                    if (item != null && item is T)
                    {
                        yield return (T)item;
                    }
                    foreach (var childOfChild in FindLogicalChildrenOfType<T>(item))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
