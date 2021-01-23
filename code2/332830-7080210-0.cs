    protected Vector2 position;    
    public GameObject(Vector2 Position, Texture2D Texture)
    {
        position = Vector2.Zero;  // <---- this needs to be position = Position
        this.texture = Texture;    
    }
    protected Vector2 Position { set; get; }
