csharp
public class someModel:INotifyPropertyChanged
{
    private BitmapImage _imageContent;
    public BitmapImage ImageContent
    {
        get => _imageContent;
        set
        {
            _imageContent = value;
            OnPropertyChanged();
        }
    }
    public string ImagePath { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
After inheriting the `INotifyPropertyChanged` interface, you can use `{x:Bind ImageContent, Mode=OneWay}` to complete the binding. When the data source is modified, the UI interface will be notified to change.
Best regards.
