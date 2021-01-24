csharp
public class Room
{
    public bool IsOpened { get; set; }
    public string Name { get; set; }
}
public class Apartment
{
    public string Name { get; set; }
    public List<Room> Rooms { get; set; }
}
2. Create a `DataTemplate` in `MainPage.xaml` and use the binding to bind the corresponding properties.
xml
<Page.Resources>
    <DataTemplate x:DataType="local:Room" x:Key="RoomItemTemplate">
        <ToggleButton IsChecked="{x:Bind IsOpened}"/>
    </DataTemplate>
    <DataTemplate x:DataType="local:Apartment" x:Key="ApartmentItemTemplate">
        <ToggleButton Content="{x:Bind Name}"/>
    </DataTemplate>
</Page.Resources>
3. Use `GridView` to bind collections.
**xaml**
xml
...
<GridView ItemTemplate="{StaticResource RoomItemTemplate}"
          x:Name="RoomGridView"
          />
<GridView ItemTemplate="{StaticResource ApartmentItemTemplate}"
          x:Name="ApartmentGridView"
          IsItemClickEnabled="True"
          ItemsSource="{x:Bind ApartmentCollection}"
          ItemClick="ApartmentGridView_ItemClick"/>
...
**xaml.cs**
csharp
public ObservableCollection<Apartment> ApartmentCollection = new ObservableCollection<Apartment>();
//...
private void ApartmentGridView_ItemClick(object sender, ItemClickEventArgs e)
{
    var item = e.ClickedItem as Apartment;
    RoomGridView.ItemsSource = item.Rooms;
}
---
It should be noted that the above code is simplified code. If you want to migrate the current code to this mode, you need to reorganize your code.
With GridView, you can use the virtualization of the control itself to reduce resource consumption. At the same time, this DataTemplate method can greatly simplify the code writing.
Regarding what you said to change the state of a single item, `ObservableCollection` has no response. This is normal, because `ObservableCollection` only responds to changes in the number of items in the collection. If you want to notify the UI when changing the properties of the data class, you need to implement the `INotifyPropertyChanged` interface for the Model.
---
Here are some documents that might help you:
- [Data binding](https://docs.microsoft.com/en-us/windows/uwp/data-binding/data-binding-quickstart)
- [Data binding and MVVM](https://docs.microsoft.com/en-us/windows/uwp/data-binding/data-binding-and-mvvm)
- [Xaml Bind Sample](https://github.com/microsoft/Windows-universal-samples/tree/master/Samples/XamlBind)
Best regards.
