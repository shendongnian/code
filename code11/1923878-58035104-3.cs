    class Program
    {
        public static Dictionary<ConsoleKey, String> inputMap = new Dictionary<ConsoleKey, string>();
        public static Dictionary<Timer, ConsoleKey> TimerKeyMap = new Dictionary<Timer, ConsoleKey>();
        public static bool continueLoop = true;
        public static object locker = new object();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.run();
        }
        public void run()
        {
            Timer keyPressedPrompter = new Timer();
            keyPressedPrompter.Interval = 60;
            keyPressedPrompter.Elapsed += new ElapsedEventHandler(KeyPressedPrompterEvent);
            keyPressedPrompter.Enabled = true;
            foreach (ConsoleKey key in Enum.GetValues(typeof(ConsoleKey)))
            {
                Timer timer = new Timer();
                TimerKeyMap[timer] = key;
                timer.Interval = 60;
                timer.Elapsed += new ElapsedEventHandler(KeyPressedCheckerEvent);
                timer.Enabled = true;
            }
            Console.WriteLine("Current inputs:");
            while (continueLoop) { }
        }
        public static void KeyPressedCheckerEvent(object source, EventArgs e)
        {
            lock (locker)
            {
                if (NativeKeyboard.IsKeyDown((int)TimerKeyMap[(Timer)source]))
                {
                    if (TimerKeyMap[(Timer)source] == ConsoleKey.Escape)
                        continueLoop = false;
                    //Console.WriteLine(KeyTimerMapReverse[(Timer)source].ToString()+ " pressed");
                    inputMap[TimerKeyMap[(Timer)source]] = TimerKeyMap[(Timer)source].ToString() + " ";
                }
                else
                {
                    // Console.WriteLine(KeyTimerMapReverse[(Timer)source].ToString() + " released");
                    inputMap[TimerKeyMap[(Timer)source]] = "";
                }
            }
        }
        public static void KeyPressedPrompterEvent(object source, EventArgs e)
        {
            Console.Write("                                             ");//clear the line - -  can be extended
            Console.Write("\r");
            lock (locker)
            {
                foreach (KeyValuePair<ConsoleKey, String> entry in inputMap)
                {
                    // do something with entry.Value or entry.Key
                    Console.Write(entry.Value);
                }
            }
        }
    }
    /// <summary>
    /// Provides keyboard access.
    /// </summary>
    internal static class NativeKeyboard
    {
        /// <summary>
        /// A positional bit flag indicating the part of a key state denoting
        /// key pressed.
        /// </summary>
        private const int KeyPressed = 0x8000;
        /// <summary>
        /// Returns a value indicating if a given key is pressed.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>
        /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
        /// </returns>
        public static bool IsKeyDown(int key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }
        /// <summary>
        /// Gets the key state of a key.
        /// </summary>
        /// <param name="key">Virtuak-key code for key.</param>
        /// <returns>The state of the key.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    } 
