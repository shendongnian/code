	<MenuItem Header="menu">
		<MenuItem x:Name="item1" Header="item1" IsCheckable="true" ></MenuItem>
		<MenuItem x:Name="item2" Header="item2" IsCheckable="true"></MenuItem>
		<MenuItem x:Name="item3" Header="item3" IsCheckable="true" ></MenuItem>
		
		<i:Interaction.Behaviors>
		<local:MenuItemButtonGroupBehavior></local:MenuItemButtonGroupBehavior>
		</i:Interaction.Behaviors>
		
	</MenuItem>
    public class MenuItemButtonGroupBehavior : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            GetCheckableSubMenuItems(AssociatedObject)
                .ToList()
                .ForEach(item => item.Click += OnClick);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            GetCheckableSubMenuItems(AssociatedObject)
                .ToList()
                .ForEach(item => item.Click -= OnClick);
        }
        private static IEnumerable<MenuItem> GetCheckableSubMenuItems(ItemsControl menuItem)
        {
            var itemCollection = menuItem.Items;
            return itemCollection.OfType<MenuItem>().Where(menuItemCandidate => menuItemCandidate.IsCheckable);
        }
        private void OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var menuItem = (MenuItem)sender;
            if (!menuItem.IsChecked)
            {
                menuItem.IsChecked = true;
                return;
            }
            GetCheckableSubMenuItems(AssociatedObject)
                .Where(item => item != menuItem)
                .ToList()
                .ForEach(item => item.IsChecked = false);
        }
    }
