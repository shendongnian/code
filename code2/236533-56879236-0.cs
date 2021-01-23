C#
public class DataGridEx : DataGrid
{
    public DataGridEx() : base()
    {
        // Create event for right click on headers
        var style = new Style { TargetType = typeof(DataGridColumnHeader) };
        var eventSetter = new EventSetter(MouseRightButtonDownEvent, new MouseButtonEventHandler(HeaderClick));
        style.Setters.Add(eventSetter);
        ColumnHeaderStyle = style;
    }
    private void HeaderClick(object sender, MouseButtonEventArgs e)
    {
        ContextMenu menu = new ContextMenu();
        // Fill context menu with column names and checkboxes
        var visibleColumns = this.Columns.Where(c => c.Visibility == Visibility.Visible).Count();
        foreach (var column in this.Columns)
        {
            var menuItem = new MenuItem
            {
                Header = column.Header.ToString(),
                IsChecked = column.Visibility == Visibility.Visible,
                IsCheckable = true,
                // Don't allow user to hide all columns
                IsEnabled = visibleColumns > 1 || column.Visibility != Visibility.Visible
            };
            // Bind events
            menuItem.Checked += (object a, RoutedEventArgs ea)
                => column.Visibility = Visibility.Visible;
            menuItem.Unchecked += (object b, RoutedEventArgs eb)
                => column.Visibility = Visibility.Collapsed;
            menu.Items.Add(menuItem);
        }
        // Open it
        menu.IsOpen = true;
    }
}
Now you can use this control instead of original `DataGrid`:
XAML
<dg:DataGridEx ItemsSource="{Binding OfflineData, UpdateSourceTrigger=PropertyChanged}" AutoGenerateColumns="False">
    <dg:DataGridEx.Columns>
        <DataGridTextColumn Binding="{Binding PortID}" Header="ID" Width="50" Visibility="Collapsed"/>
        <DataGridTextColumn Binding="{Binding SwitchIP}" Header="Switch IP" Width="100" Visibility="Visible"/>
        <DataGridTextColumn Binding="{Binding Port}" Header="Port" Width="50" Visibility="Visible"/>
    </dg:DataGridEx.Columns>
</dg:DataGridEx>
Now user can right-click on column header to open menu with checkboxes:
[![Now user can right-click on column header to open menu with checkboxes][1]][1]
  [1]: https://i.stack.imgur.com/RwFYF.png
