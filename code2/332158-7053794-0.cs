    class GameObject
    {
        protected Texture2D _texture;
        public GameObject(Vector2 position, Texture2D tex)
        {
            ...
            _texture = tex;
        }
    }
     
    class Player : GameObject
    {
        public Player(Vector2 position, Texture2D tex):base(position,tex)
        {
        }
    
        public override void Draw(...)
        {
            // _texture should be accessible from here.
        }
    }
