    namespace MySilverlightApplication
    {
        public class PlatformInvokeTest
        {
            [DllImport("kernel32.dll")]
            public static extern bool Beep(int frequency, int duration);
     
        
            public static void PlaySound(int frequency, int duration)
            {
              Beep(frequency, duration);
            }
        }
    }
