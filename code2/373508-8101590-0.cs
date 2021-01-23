	public class Item
	{
		  public Vector2 Position;
		  static Sprite mySprite;
		  protected virtual Sprite getMySprite() { return mySprite; } // Virtualize getting the sprite
		  public void Draw() {Draw getMySprite() at Position}
	}
	public class Couch:Item
	{
		  static Sprite mySprite=someCouchImage;
		  override Sprite getMySprite() { return mySprite; } // Get the custom sprite
	}
	public class Table:Item
	{
		  static Sprite mySprite=someTableImage;
		  override Sprite getMySprite() { return mySprite; } // Get the custom sprite
	}
 
