    public interface IKillable
    {
        void Kill();
    }
    
    public interface IExplodable : IKillable
    {
         float TimeLeft { get; set; }
         void Timer(float timeToExplode);
    }
    
    public abstract class TimerExplodableDevice: MonoBehaviour, IExplodable
    {
        public float TimeLeft { get; set; }
    
        public virtual void Kill()
        {
            //Destroy the object
        }
    
        public virtual void Timer(float timeLeft)
        {
            if (TimeLeft <= 0) 
            {
                Kill();
            }
        }
    }
    // this should be in a "Devices" folder, or otherwise be called appropriately
    public class Backpack : TimerExplodableDevice
    {
        void Start()
        {
            TimeLeft = 100;
        }
    }
    // this should be in a "Devices" folder, or otherwise be called appropriately
    public class Bomb : TimerExplodableDevice
    {
        void Start()
        {
            TimeLeft = 10;
        }
    }
