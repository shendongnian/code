    // must inject the camera for this solution
    static void Main(string[] args)
    {
        new Game1(new ChaseCamera()).Play();
        Console.ReadLine();
    }
    // abstract game
    abstract class GameBase
    {
        public virtual CameraBase Camera { get; set; }
        public GameBase(CameraBase camera) // injection
        {
            Camera = camera;
        }
        public virtual void Play()
        {
            Console.WriteLine("GameBase.Camera is null? {0}", Camera == null);
            if (Camera != null)
                Camera.SpecialCameraBaseMethod();
        }
    }
    // awesome game using chase cameras
    class Game1 : GameBase
    {
        public new ChaseCamera Camera 
        { 
            get { return (ChaseCamera)base.Camera; } 
            set { base.Camera = value; } 
        }
        public Game1(ChaseCamera camera) : base(camera) { } // injection
        public override void Play()
        {
            Console.WriteLine("Game.Camera is null? {0}", Camera == null);
            Camera.SpecialChaseCameraMethod();
            base.Play();
        }
    }
