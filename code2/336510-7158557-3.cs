    public class Timer
    {
        public Action Trigger;
        public float Interval;
        float Elapsed;
        Timer() {}
        public void Update(float Seconds)
        {
            Elapsed+= Seconds;
            if (Elapsed>= Interval)
            {
                 Trigger.Invoke();
                 Destroy();
            }
        }
        public void Destroy()
        {
            TimerManager.Remove(this);
        }
        public static void Create(float Interval, Action Trigger)
        {
            Timer Timer = new Timer() { Interval = Interval, Trigger = Trigger }
            TimerManager.Add(this);
        }
    }
    public class TimerManager : GameComponent
    {
         List<Timer> ToRemove = new List();
         List<Timer> Timers = new List();
         public static TimerManager Instance;
         public static void Add(Timer Timer) { Instance.Timers.Add( Timer ); }
         public static void Remove(Timer Timer) { Instance.ToRemove.Add(Timer); }
         public void Update(GameTime gametime)
         {
             foreach (Timer timer in ToRemove) Timers.Remove(timer);
             foreach (Timer timer in Timers) timer.Update( (float) gametime.Elapsed.Totalseconds); 
         }
    }
    public class Game
    {
         public void Initialize() { Components.Add(new TimerManager(this);}
         public Update()
         {
              if (HasToShowCard(out card)) 
              {
                  Timer.Create(1, () => card.Show());
              }
         }
    }   
