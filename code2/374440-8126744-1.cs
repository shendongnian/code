    public class Sprite
    {
        public Vector2 Position = Vector2.Zero;
        public Texture2D Texture;
        public float Scale = 1;
    
    
        public void LoadAsset(Game game, string asset)
        {
             Texture = game.Content.Load<Texture2d>(asset);
        } 
    
        public Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, null, Color.White, ...,... Scale,...);
        }
    }
    
    
    //In your game:
    
    List<Sprite> Sprites = new List<Sprite>();
    
    Initialize()
    {
        base.Initialize();
        Sprite myBox = new Box();
        myBox.LoadAsset("Box"); 
        Sprites.Add(myBox);
    }
    
    
    Update(GameTime gametime)
    {
        myBox.Position += Vector2.UnitX * Speed * (float) gametime.elapsed.TotalSeconds;
    }
    
    
    Draw()
    {
        batch.begin();
        foreach (Sprite sprite in Sprites) sprite.Draw(batch);
        batch.end();   
    }
