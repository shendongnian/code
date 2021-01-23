    public abstact class GameObject
    {
      protected Texture2D _texture;
      public abstract void Draw();
    
      public GameObject(Texture2D tex) { 
        _texture = tex;
      }
    }
    
    public class Player : GameObject
    {
      public Player(Texture2D tex) : base (tex) { }
    
      public override Draw()
      {
         //Do stuff with _texture.
      }
    }
