C#
private MyClass _selectedItem;
Then, register the RightTapped event of your `ListView`:
XML
<ListView x:Name="myList" RightTapped="myList_RightTapped">
From there, get the DataContext from the `RightTappedRoutedEventArgs`:
C#
private void myList_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e) {
    _selectedItem = (e.OriginalSource as FrameworkElement).DataContext as MyClass;
}
When your flyout's `Click` event is fired, use `_selectedValue`:
C#
private void MenuFlyoutItem_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
    // Do stuff with _selectedValue
}
**Full example files:**
MainPage.cs:
C#
 public sealed partial class MainPage : Page {
    #region Fields
    private List<MyClass> _items;
    private MyClass _selectedItem;
    #endregion
    public MainPage() {
        this.InitializeComponent();
        _items = new List<MyClass>();
        _items.Add(new MyClass() { Name = "O" });
        _items.Add(new MyClass() { Name = "P" });
        myList.ItemsSource = _items;
    }
    private void MenuFlyoutItem_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
        // Do stuff with _selectedValue
    }
    private void myList_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e) {
        _selectedItem = (e.OriginalSource as FrameworkElement).DataContext as MyClass;
    }
    public class MyClass {
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
MainPage.xaml:
XML
<Page
    x:Class="UWP.Sandbox.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:UWP.Sandbox"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid>
        <ListView x:Name="myList" RightTapped="myList_RightTapped">
            <ListView.ContextFlyout>
                <MenuFlyout x:Name="itemActual">
                    <MenuFlyoutItem Text="see" Click="MenuFlyoutItem_Click"/>
                </MenuFlyout>
            </ListView.ContextFlyout>
        </ListView>
    </Grid>
</Page>
