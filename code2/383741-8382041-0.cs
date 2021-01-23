    public class MyClass
    {
        ContentManager content;
        Texture2D sprite;
    
        public MyClass(ContentManager content)
        {
            this.content = content;
        }
    
        public void LoadSprite(string filename)
        {
            sprite = this.content.Load<Texture2D>(filename);
        }
    }
