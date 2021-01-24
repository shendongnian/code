    public partial class MyForm
    {
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public MyForm()
        {
            InitializeComponent();
            // ...
            _timer.Interval = 15000; // Run Tick(s, e) event handler every 15 secs.
            _timer.Tick +=
                (s, e) =>
                {
                    // Here you put whatever code you want to run at 15 secs
                    // interval. Code is run on UI thread, so you can update
                    // UI at will.
                }
        }
    }
