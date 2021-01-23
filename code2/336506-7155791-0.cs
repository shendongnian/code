    using System.Timers;
    .
    .
    .    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Timer t = new Timer(1000);
        //The number is the interval in miliseconds
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Enabled = true;
        }
        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //code
        }
    .
    .
    .
    }
