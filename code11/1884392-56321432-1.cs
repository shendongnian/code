    public sealed partial class MainPage : Page
    {
        private int countDowm = 60;
        private int RemainingTime = 120;
        private int loopTimes = 0;
        public MainPage()
        {
            this.InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, object e)
        {
            if (loopTimes == 5)
            {
                countDowm = 60;
                RemainingTime = 120;
                loopTimes = 0;
            }
            else
            {
                if (countDowm <= 0)
                {
                    if (RemainingTime <= 0)
                    {
                        loopTimes++;
                        countDowm = 60;
                        RemainingTime = 120;
                    }
                    else
                    {
                        RemainingTime--;
                    }
                }
                else
                {
                    countDowm--;
                }
            }
            countDown1.Text = countDowm.ToString();
            pauseRemaning.Text = RemainingTime.ToString();
            loop_Times.Text = loopTimes.ToString();
        }
    }
