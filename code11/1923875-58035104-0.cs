    public class Program
    {
        public static Dictionary<ConsoleKey, String> inputMap = new Dictionary<ConsoleKey, string>();
        public static Dictionary<ConsoleKey, Timer> KeyTimerMap = new Dictionary<ConsoleKey, Timer>();
        public static Dictionary<Timer, ConsoleKey> KeyTimerMapReverse = new Dictionary<Timer, ConsoleKey>();
      
        static void Main(string[] args)
        {
            Timer keyPressedPrompter = new Timer();
            keyPressedPrompter.Interval = 100;
            keyPressedPrompter.Elapsed += new ElapsedEventHandler(KeyPressedPrompterEvent);
            keyPressedPrompter.Enabled = true; 
            ConsoleKeyInfo keyinfo;
            while (true)
            {
                if (Console.KeyAvailable)
                { 
                    keyinfo = Console.ReadKey();
                    if (KeyTimerMap.ContainsKey(keyinfo.Key))
                    {
                        //restart timer for the target key 
                        KeyTimerMap[keyinfo.Key].Stop();
                        KeyTimerMap[keyinfo.Key].Start();
                    }
                    else
                    {
                        Timer keyUniqueTimer = new Timer();
                        keyUniqueTimer.AutoReset = false;// timer do not repeat
                        keyUniqueTimer.Interval = 35;// time delay for readkey for a pressed key is supposely 30~ ms
                        keyUniqueTimer.Elapsed += new ElapsedEventHandler(KeyUniqueTimerCountDown);
                        keyUniqueTimer.Enabled = true;
                        KeyTimerMap[keyinfo.Key] = keyUniqueTimer;
                        KeyTimerMapReverse[keyUniqueTimer] = keyinfo.Key;
                    }
                    //Console.WriteLine("keyinfo.Key.ToString(): "+ keyinfo.Key.ToString());
                    inputMap[keyinfo.Key] = keyinfo.Key.ToString();
                    if (keyinfo.Key.ToString().Equals("Escape")) // hit ESC key to exit
                        break;
                }
            }
        }
        public static void KeyUniqueTimerCountDown(object source, EventArgs e)
        {
            // if this function is called , it means that related key is not being pressed anymore // key released
            inputMap[KeyTimerMapReverse[((Timer)source)]] = "";// erase the value from the pressed keys cache
        }
        public static void KeyPressedPrompterEvent(object source, EventArgs e)
        {
            Console.Write("                                             ");//clear the line - -  can be extended
            Console.Write("\r");// reset the to start of the line 
            foreach (KeyValuePair<ConsoleKey, String> entry in inputMap)
            {
                // do something with entry.Value or entry.Key
                Console.Write(entry.Value);
            }
        }
    }
