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
    public class Game1
    {
        ContentManager content;
    
        public void LoadContent()
        {
             MyClass myclass = new MyClass(content);
        }
    
    }
