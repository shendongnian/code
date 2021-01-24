csharp
public class FavoritesManager
{
    // The only instance. Readonly, because it is never re-assigned.
    public readonly static It => new FavoritesManager();
    public readonly ObservableCollection<string> FavoritesList = new ObservableCollection<string>();
    // Private, so no other instances can be created.
    private FavoritesManager()
    {
    }
    ...
}
Usage:
csharp
    ... FavoritesManager.It...
So you do everything you are accustomed to doing, such as defining an indexer. And you refer to the one instance by `FavoritesManager.It`.
