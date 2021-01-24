csharp
public class MyNode : INotifyPropertyChanged
{
    private bool isExpanded;
    public string Name { get; set; }
    public string Type { get; set; }
    public bool IsExpanded
    {
        get => isExpanded;
        set
        {
            isExpanded = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsExpanded)));
        }
    }
    public ObservableCollection<MyNode> nodes { get; set; }
    public MyNode(string theName, string theType)
    {
        Name = theName;
        Type = theType;
        nodes = new ObservableCollection<MyNode>();
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged
