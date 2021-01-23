    public static class MenuBehavior
    {
        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        public static string GetOptionGroupName(MenuItem obj)
        {
            return (string)obj.GetValue(OptionGroupNameProperty);
        }
        public static void SetOptionGroupName(MenuItem obj, string value)
        {
            obj.SetValue(OptionGroupNameProperty, value);
        }
        public static readonly DependencyProperty OptionGroupNameProperty =
            DependencyProperty.RegisterAttached(
              "OptionGroupName",
              typeof(string),
              typeof(MenuBehavior),
              new UIPropertyMetadata(
                null,
                OptionGroupNameChanged));
        private static void OptionGroupNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var menuItem = o as MenuItem;
            if (menuItem == null)
                return;
            var oldValue = (string)e.OldValue;
            var newValue = (string)e.NewValue;
            if (!string.IsNullOrEmpty(oldValue))
            {
                RemoveFromOptionGroup(menuItem, oldValue);
            }
            if (!string.IsNullOrEmpty(newValue))
            {
                AddToOptionGroup(menuItem, newValue);
            }
        }
        private static readonly Dictionary<string, HashSet<MenuItem>> _optionGroups =
            new Dictionary<string, HashSet<MenuItem>>();
        private static void AddToOptionGroup(MenuItem menuItem, string groupName)
        {
            HashSet<MenuItem> group;
            if (!_optionGroups.TryGetValue(groupName, out group))
            {
                group = new HashSet<MenuItem>();
                _optionGroups[groupName] = group;
            }
            if (group.Add(menuItem))
                menuItem.Checked += menuItem_Checked;
        }
        private static void RemoveFromOptionGroup(MenuItem menuItem, string groupName)
        {
            HashSet<MenuItem> group;
            if (!_optionGroups.TryGetValue(groupName, out group))
                return;
            if (group.Remove(menuItem))
                menuItem.Checked -= menuItem_Checked;
        }
        static void menuItem_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem == null)
                return;
            
            string groupName = GetOptionGroupName(menuItem);
            if (groupName == null)
                return;
            HashSet<MenuItem> group;
            if (!_optionGroups.TryGetValue(groupName, out group))
                return;
            foreach (var item in group)
            {
                if (item != menuItem)
                    item.IsChecked = false;
            }
        }
    }
