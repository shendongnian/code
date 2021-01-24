    public class Example
    {
        private static System.Timers.Timer aTimer;
        static int[] randomNumbers = new int[] { 1, 2, 4, 5, 645, 65, 56, 5, 645, 6, 546, 45 };
        static int index = 0;
        static readonly int arrayLength = randomNumbers.Length;
        public static void Main()
        {
            SetTimer(2000);
            Console.ReadKey();
        }
        private static void SetTimer(int timeInMiliseconds)
        {
            aTimer = new System.Timers.Timer(timeInMiliseconds);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Start();
        }
        public static void StopTimer()
        {
            aTimer.Stop();
            aTimer.Dispose();
            System.Console.WriteLine("Timer stopped");
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (index < arrayLength)
            {
                Console.WriteLine(randomNumbers[index]);
                index++;
            }
            else
                StopTimer();
        }
    }
Tested and working
