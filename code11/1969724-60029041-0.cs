csharp
public sealed class FavoritesManager
{
	// Instance for Singleton pattern
	public static FavoritesManager Instance { get; } = new FavoritesManager();
	// Singleton pattern : no other instance permitted ==> static & private constructor
	static FavoritesManager()
	{ }
	private FavoritesManager()
	{ }
	// Collection of all favorites
	public ObservableCollection<string> Favorites { get; private set; } = new ObservableCollection<string>();
	// If needed, access from indexer
	public bool this[string key]
	{
		get => this.Favorites.Contains(key);
	}
}
