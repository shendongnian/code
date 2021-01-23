    MyPlayer = new Player(new Vector2(500, 700), Bat,new Vector2(5,5),new Vector2(Bat.Width / 2,Bat.Height/2),graphics);
    playerTexture = MyPlayer.Load(Content);
    ...
    public Texture2D Load(ContentManager Content)
    {
        return Content.Load<Texture2D>("Images/pong");
    }
