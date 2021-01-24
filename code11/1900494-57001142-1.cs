    public partial class Form1 : Form
    {
        private readonly ITimerWrapper _timerWrapper;
        public Form1(ITimerWrapper timerWrapper)
        {
            InitializeComponent();
            this._timerWrapper = timerWrapper; // of course this is done via dependency injection
            this._timerWrapper.Interval = 1000;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // now you can mock this interface
            this._timerWrapper.AddTickHandler(this.Tick_Event);
            this._timerWrapper.Start();
        }
        private void Tick_Event(object sender, EventArgs e)
        {
            Console.WriteLine("tick tock");
        }
    }
    public interface ITimerWrapper
    {
        void AddTickHandler(EventHandler eventHandler);
        void Start();
        void Stop();
        int Interval { get; set; }
    }
    public class TimerWrapper : ITimerWrapper
    {
        private readonly Timer _timer;
        public TimerWrapper()
        {
            this._timer = new Timer();
        }
        public int Interval
        {
            get
            {
                return this._timer.Interval;
            }
            set
            {
                this._timer.Interval = value;
            }
        }
        public void AddTickHandler(EventHandler eventHandler)
        {
            this._timer.Tick += eventHandler;
        }
        public void Start()
        {
            this._timer.Start();
        }
        public void Stop()
        {
            this._timer.Stop();
        }
    }
