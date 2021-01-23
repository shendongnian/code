    // Note: Taken from http://www.opentk.com
    // Yet Another Starter Kit by Hortus Longus
    // (http://www.opentk.com/project/Yask)
    partial class Game : GameWindow
    {        
        /// <summary>Init stuff.</summary>
        public Game()
          : base(800, 600, OpenTK.Graphics.GraphicsMode.Default, "My Game")
        { VSync = VSyncMode.On; }
        /// <summary>Load resources here.</summary>
        protected override void OnLoad(EventArgs e)
        {
          base.OnLoad(e);
          // load stuff
        }
        /// <summary>Called when your window is resized.
        /// Set your viewport/projection matrix here.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
          base.OnResize(e);
          // do resize stuff
        }
        /// <summary>
        /// Called when it is time to setup the next frame. Add you game logic here.
        /// </summary>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
          base.OnUpdateFrame(e);
          TimeSlice();
          // handle keyboard here
        }
        /// <summary>
        /// Called when it is time to render the next frame. Add your rendering code here.
        /// </summary>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
          base.OnRenderFrame(e);
          // do your rendering here
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Game game = new Game())
            {
                game.Run(30.0);
            }
        }
    }
