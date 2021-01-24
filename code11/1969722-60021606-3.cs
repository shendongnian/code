csharp
public class FavoritesManager
{
    // The only instance. Readonly, because it is never re-assigned.
    public readonly static It => new FavoritesManager();
    // "get", so that it is a `property`. This is necessary for `ObservableCollection` to be seen via binding.
    public readonly ObservableCollection<string> FavoritesList {get;} = new ObservableCollection<string>();
    // Private, so no other instances can be created.
    private FavoritesManager()
    {
    }
    ...
}
Usage:
csharp
    ... FavoritesManager.It...
Then do everything you are accustomed to doing, such as defining an indexer. And refer to the one instance (from code in other classes) by `FavoritesManager.It`.
-------------------------------
My answer above may be incomplete, re your `Binding` question. However, note the one change I've made:  XAML Bindings only see *properties*: the `ObservableCollection` must be a *property* (have a getter).
You might also need to make FavoritesManager be a BindableObject:
     public class FavoritesManager : Xamarin.Forms.BindableObject
