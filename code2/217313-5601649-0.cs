    public class Vibration
        {
            public static void VibrateOnButtonPress()
            {
                Microsoft.Devices.VibrateController.Default.Start(TimeSpan.FromMilliseconds(50));
                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                timer.Tick += (tsender, tevt) =>
                {
                    var t = tsender as System.Windows.Threading.DispatcherTimer;
                    t.Stop();
                    Microsoft.Devices.VibrateController.Default.Stop();
                };
                timer.Start();
            }
        }
