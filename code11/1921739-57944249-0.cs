cs
public class ProductViewModel {
	/// <summary>
	/// Backing field for the IsSelected property
	/// </summary>
	private bool _isSelected;
	/// <summary>
	/// Gets or sets the collection of materials used to build this Product.
	/// </summary>
	public ObservableCollection<ProductViewModel> SubProducts { get; set; } = new ObservableCollection<ProductViewModel>();
	/// <summary>
	/// Gets or sets the name of this product.
	/// </summary>
	public string ProductName { get; set; }
	/// <summary>
	/// Gets or sets the selected state of this product.
	/// </summary>
	public bool IsSelected {
		get => _isSelected;
		set {
			//The product has been selected or deselected.
			if (!_isSelected && SubProducts.Count == 0) {
				//We load data into it if not already done.
				LoadSubProductsCollectionFromDataSource();
			}
			_isSelected = value;
		}
	}
	/// <summary>
	/// Loads sub products data into this product.
	/// </summary>
	private void LoadSubProductsCollectionFromDataSource() {
		//..
		//Do stuff to retrieve your data dynamically and
		//add them to the SubProducts collection.
		//...
		for (int i = 0; i < 5; i++) {
			//Add dummy items
			SubProducts.Add(new ProductViewModel() { ProductName = "Some product " + i.ToString() });
		}
	}
}
In your MainWindow.xaml.cs, initialize and expose a collection of view model objects like this:
cs
public partial class MainWindow : Window {
	/// <summary>
	/// Exposes the root product of the tree
	/// </summary>
	public ObservableCollection<ProductViewModel> RootProducts { get; } = new ObservableCollection<ProductViewModel>();
	public MainWindow() {
		InitializeComponent();
		RootProducts.Add(new ProductViewModel() { ProductName = "Root product" });
	}
}
This collection would normally be stored in a main viewmodel object but for simplicity I just created it in the MainWindow. Notice how I expose it as a property (to allow Binding) and as an ObservableCollection (to automatically notify the view when the collection changes).
Finally, tell your view how to display your ProductViewModel objects using a TreeView:
xaml
<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        x:Name="window"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
		<!--Tell the treeview how to hierarchically display and organize ProductViewModel items-->
        <HierarchicalDataTemplate DataType="{x:Type local:ProductViewModel}" ItemsSource="{Binding SubProducts}">
            <TextBlock Text="{Binding ProductName}"></TextBlock>
        </HierarchicalDataTemplate>
		<!--Tell each treeviewitem to bind IsSelected to the PoductViewModel.ISSelected property.-->
        <Style TargetType="TreeViewItem">
            <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}"></Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <TreeView ItemsSource="{Binding ElementName=window, Path=RootProducts}"/>
    </Grid>
</Window>
Now, every time you select a ```TreeViewItem``` in your ```TreeView```, its ```IsSelected``` property is set to true (this is the behavior of a ```TreeViewItem```). Because of our binding, it also sets to true the ```IsSelected``` property of the corresponding ```ProductViewModel```. In the setter of this property, we make a call to populate the list of subproducts. Because this list is actually an ```ObservableCollection```, it notifies the View (the ```TreeView```) which knows it should update itself with new ```TreeViewItems```.
