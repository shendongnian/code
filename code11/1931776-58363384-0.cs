xaml
<ItemsControl ItemsSource="{Binding Items}">
	<!-- Place all items in a WrapPanel -->
	<ItemsControl.ItemsPanel>
		<ItemsPanelTemplate>
			<WrapPanel x:Name="filterWrapper" Orientation="Horizontal"/>
		</ItemsPanelTemplate>
	</ItemsControl.ItemsPanel>
	<!-- Define the look of each item -->
	<ItemsControl.ItemTemplate>
		<DataTemplate DataType="{x:Type wpfapp1:FilterField}">
			<Border>
				<WrapPanel>
					<TextBlock Text="{Binding FilterName}"/>
					<TextBlock Text="x"/>
				</WrapPanel>
			</Border>
		</DataTemplate>
	</ItemsControl.ItemTemplate>
</ItemsControl>
The `DataTemplate` you define in `ItemsControl.ItemTemplate` gets applied to all items in the source collection, and each item gets added in the `ItemsControl.ItemsPanel` that you define, here a `WrapPanel`.
This is assuming you have a a collection `Items` of type `List<FilterField>` in your view model, like this:
cs
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
		DataContext = new MyViewModel();
	}
}
public class MyViewModel {
	public List<FilterField> Items { get; set; } = new List<FilterField> {
		new FilterField() { FilterName = "Test_1"},
		new FilterField() { FilterName = "Test_2"},
		new FilterField() { FilterName = "Test_3"},
	};
}
public class FilterField {
	public string FilterName { get; set; }
}
