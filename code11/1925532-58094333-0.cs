xaml
<TreeView
	ItemsSource="{Binding Foods}">
	<TreeView.Resources>
		<HierarchicalDataTemplate DataType="{x:Type domain:Food}" ItemsSource="{Binding Fruits}">
			<StackPanel Orientation="Horizontal">
				<CheckBox
					IsChecked="{Binding SelectAll}" />
				<TextBlock Text="   " />
				<TextBlock Text="{Binding Name}" />
			</StackPanel>
		</HierarchicalDataTemplate>
		<DataTemplate DataType="{x:Type domain:Fruit}">
			<!-- Here I added the StackPanel and the CheckBox -->
			<StackPanel Orientation="Horizontal">
				<CheckBox IsChecked="{Binding IsSelected}" />
				<TextBlock Text="{Binding Name}" />
			</StackPanel>
		</DataTemplate>
	</TreeView.Resources>
</TreeView>
After that I did some code changes, mainly I just implemented INotifyPropertyChanged. So the Food and Fruit class look like this now:
c#
public class Food
{
    public string Name { get; set; }
    public ObservableCollection<Fruit> Fruits { get; set; }
    private bool _selectAll;
    public bool SelectAll
    {
        get => _selectAll;
        set
        {
            _selectAll = value;
            foreach (var f in Fruits)
                f.IsSelected = value;
        }
    }
}
And Fruit like this
c#
public class Fruit : INotifyPropertyChanged
{
    public string Name { get; set; }
    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
**Edit:** INotifyPropertyChanged isn't needed on Food
