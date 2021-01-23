    public class Item
    {
    	public Vector2 Position;
    	
    	protected static Dictionary<Type, Sprite> sprites = new Dictionary<Type, Sprite>();
    	public static void RegisterSprite(Type type, Sprite sprite)
    	{
    		sprites.Add(type, sprite);
    	}
        
    	public void Draw() {
                Draw sprites.Item(typeof(this)) at Position
        }
    }
    
    public class Couch:Item {}
    public class Table:Item {}
