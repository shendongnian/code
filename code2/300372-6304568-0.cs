    class GameAndCameraExample
    {
        static void Main(string[] args)
        {
            new Game1().Play();
            Console.WriteLine();
            new Game2().Play();
            Console.ReadLine();
        }    
        
        // abstract camera  
        abstract class CameraBase
        {
            public void SpecialCameraBaseMethod()
            {
                Console.WriteLine("SpecialCameraBaseMethod");
            }
        }    
        
        // camera implementation    
        class ChaseCamera : CameraBase
        {
            public void SpecialChaseCameraMethod()
            {
                Console.WriteLine("SpecialChaseCameraMethod");
            }
        }    
        
        // a different camera implementation   
        class FlightCamera : CameraBase
        {
            public void SpecialFlightCameraMethod()
            {
                Console.WriteLine("SpecialFlightCameraMethod");
            }
        }    
        
        // abstract game   
        abstract class GameBase<T> where T : CameraBase, new()
        {
            public T Camera { get; set; }
            public GameBase()
            {
                Camera = new T();
            }
            
            public virtual void Play()
            {
                Console.WriteLine("GameBase.Camera is null? {0}", Camera == null); 
                if (Camera != null) // it will be null for Game2 :-(              
                    Camera.SpecialCameraBaseMethod();
            }
        }   
        
        // awesome game using chase cameras  
        class Game1 : GameBase<ChaseCamera>
        {
            public override void Play()
            {
                Console.WriteLine("Game.Camera is null? {0}", Camera == null); 
                Camera.SpecialChaseCameraMethod(); 
                base.Play();
            }
        }
        // even more awesome game using flight cameras    
        class Game2 : GameBase<FlightCamera>
        {
            public override void Play()
            {
                Console.WriteLine("Game.Camera is null? {0}", Camera == null); 
                Camera.SpecialFlightCameraMethod(); 
                base.Play();
            }
        }
    }
