csharp
public class FavoritesManager
{
    // The only instance.
    public readonly static It => new FavoritesManager();
    public readonly ObservableCollection<string> FavoritesList = new ObservableCollection<string>();
    private FavoritesManager()
    {
    }
    ...
}
Usage:
csharp
    ... FavoritesManager.It...
