c#
public class ListViewBindingExampleViewModel
{
    public List<Info> Infos { get; set; } = new List<Info>();
    private ListViewBindingExampleViewModel () { }
}
And then, in the xaml:
xaml
<ListView ItemsSource="{Binding Path=Infos}">
    <ListView.View>
            <GridView>
                <GridViewColumn Header="Name" Width="120" />
                <GridViewColumn Header="Value" Width="240" />
            </GridView>
     <ListView.View>
     <ListViewItem>
         <ListViewColumn Column="1">Serial port</ListViewColumn>
         <ListViewColumn Column="2">{Binding Path=Port}</ListViewColumn>
     </ListViewItem>
     <ListViewItem>
         <ListViewColumn Column="1">Board ID</ListViewColumn>
         <ListViewColumn Column="2">{Binding Path=BoardId}</ListViewColumn>
     </ListViewItem>
</ListView>
It is also worth to mention that the changes of a item of the `Infos` list would not be propagated to the front-end in this way. 
The best way to aproach this problem, in my opinion, would be using [Caliburn.Micro][1], in which the `ViewModel` has a `BindableCollection` that would be binded to the `ItemsSource` of the `ListView`. For example, in the view model you have this
c#
public class ListViewBindingExampleViewModel
{
    public BindableCollection<Info> Infos { get; set; } = new BindableCollection<Info>();
    private ListViewBindingExampleViewModel () { }
}
 And then, you should change your `Info` class to implement the `INotifyPropertyChanged` interface, like this:
c#
public struct Info : PropertyChangedBase
{
    private string _port;
    ...
    public string Port { get { return _port; } set { _port= value; NotifyOfPropertyChange(nameof(Port  )); } }
    ...
}
Doing it that way, if you need, the changes in the back-end would be reflected in the front-end.
  [1]: https://caliburnmicro.com/
