    // abstract game
    abstract class GameBase
    {
        public virtual CameraBase CameraBase { get; set; }
        public GameBase() { }
        public virtual void Play()
        {
            Console.WriteLine("GameBase.CameraBase is null? {0}", CameraBase == null);
            if (CameraBase != null)
                CameraBase.SpecialCameraBaseMethod();
        }
    }
    // awesome game using chase cameras
    class Game1 : GameBase
    {
        public override CameraBase CameraBase 
        { 
            get { return Camera; } 
            set { Camera = (ChaseCamera)value; } 
        }
        public ChaseCamera Camera { get; set; }
        public Game1()
        {
            Camera = new ChaseCamera();
        }
        public override void Play()
        {
            Console.WriteLine("Game.Camera is null? {0}", Camera == null);
            Camera.SpecialChaseCameraMethod();
            base.Play();
        }
    }
