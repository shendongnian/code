csharp
public class MyListItem : BaseModel
{
    private string image;
    public string Image
    {
        get => image;
        set
        {
            image = value;
            OnPropertyChanged(nameof(Image));
        }
    }
    public MyListItem(string url)
    {
        ...
        setImage(url);
    }
    private async void setImage(string url)
    {
        Image = await MyCachingLib.GetUrlAsync(url);
    }
}
public abstract class BaseModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
I've done it with `BaseModel` but you can freely put `INotifyImplementation` in your model.
In your Xaml/UI file, just bind to Image. It should work ;-)
