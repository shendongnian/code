csharp
public class Playlist:INotifyPropertyChanged
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
Then you can bind it in the `HeaderTemplate`.
xml
<controls:TabView.ItemHeaderTemplate>
    <DataTemplate x:DataType="data:Playlist">
        <TextBlock Text={x:Bind Name, Mode=OneWay} />
    </DataTemplate>
</controls:TabView.ItemHeaderTemplate>
Similarly, if you need to change the visibility of the `TextBlock`, there are two ways. 
The first is to add the `Visibility` property to the Playlist class, which is created in the same way as the `Name` property. 
The second is to convert through `IValueConverter` according to a certain condition (such as `IsEdit`).
Best regards.
