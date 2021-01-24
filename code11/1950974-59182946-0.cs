xaml
<StackPanel Orientation="Vertical">
	<StackPanel.Resources>
		<Style TargetType="ToggleButton">
			<Style.Triggers>
				<Trigger Property="IsChecked" Value="False">
					<Setter Property="MaxWidth" Value="15"/>
				</Trigger>
			</Style.Triggers>
		</Style>
	</StackPanel.Resources>
	<StackPanel Orientation="Horizontal">
		<ToggleButton x:Name="button1" Content="Button 1" Click="button1_Click"/>
		<TextBlock Text="Line 1"/>
	</StackPanel>
	<StackPanel Orientation="Horizontal">
		<ToggleButton x:Name="button2" Content="Button 2" Click="button2_Click"/>
		<TextBlock Text="Line 2"/>
	</StackPanel>
	<StackPanel Orientation="Horizontal">
		<ToggleButton x:Name="button3" Content="Button 3" Click="button3_Click"/>
		<TextBlock Text="Line 3"/>
	</StackPanel>
</StackPanel>
*Code-behind*
cs
private void button1_Click(object sender, RoutedEventArgs e) {
	if (button1.IsChecked == true) {
		button2.IsChecked = false;
		button3.IsChecked = false;
	}
}
private void button2_Click(object sender, RoutedEventArgs e) {
	if (button2.IsChecked == true) {
		button1.IsChecked = false;
		button3.IsChecked = false;
	}
}
private void button3_Click(object sender, RoutedEventArgs e) {
	if (button3.IsChecked == true) {
		button1.IsChecked = false;
		button2.IsChecked = false;
	}
}
This method is tedious, error-prone, requires code-behind and is not very scalable.
**Binding `IsChecked` properties to a collection of `bool` with one `true` at a time.**
Another way you could go (still by using code-behind) is to define a collection of boolean values and bind each `ToggleButton.IsChecked` on one of the `bool` in the collection, and ensure that the collection only contains at most one `true` at a time:
xaml        
<StackPanel Orientation="Horizontal">
	<ToggleButton x:Name="button1" Content="Button 1" IsChecked="{Binding [0]}"/>
	<TextBlock Text="Line 1"/>
</StackPanel>
<StackPanel Orientation="Horizontal">
	<ToggleButton x:Name="button2" Content="Button 2" IsChecked="{Binding [1]}"/>
	<TextBlock Text="Line 2"/>
</StackPanel>
<StackPanel Orientation="Horizontal">
	<ToggleButton x:Name="button3" Content="Button 3" IsChecked="{Binding [2]}"/>
	<TextBlock Text="Line 3"/>
</StackPanel>
*Code-behind*
cs
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
		ObservableCollection<bool> states = new ObservableCollection<bool> { false, false, false };
		states.CollectionChanged += States_CollectionChanged;
		DataContext = states;
	}
	private void States_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
		var collection = sender as ObservableCollection<bool>;
		if (e.Action == NotifyCollectionChangedAction.Replace) {
			if ((bool)e.NewItems[0]) {
				for (int i = 0; i < collection.Count; i++) {
					if (e.NewStartingIndex != i) {
						collection[i] = false;
					}
				}
			}
		}
	}
}
Again, this uses code-behind and not the view model but at least it is easier to add rows.
