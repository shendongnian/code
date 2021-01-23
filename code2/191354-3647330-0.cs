    public class ExampleApp
    {
        private int _currentMoney = 1450;
        private int _lastNotificationStep = 29; // 50 * 30 = 1500
        [STAThread]
        public static void Main(string[] argv)
        {
            var app = new ExampleApp();
            app.InYourLoop(50);
            app.InYourLoop(30);
            app.InYourLoop(40);
        }
        public void InYourLoop(int deposited)
        {
            int total = _currentMoney + deposited;
            var currentStep = (int) Math.Floor(total/50d);
            if (_lastNotificationStep != currentStep && total >= 1500)
            {
                for (int step = _lastNotificationStep; step < currentStep; ++step)
                {
                    Console.WriteLine("Notification of step: " + currentStep + " for total " + total);
                    _lastNotificationStep = currentStep;
                }
            }
            _currentMoney = total;
        }
    }
