    using System;
    using System.Diagnostics;
    using System.Timers;
    namespace TimerTest
    {
        class Program
        {
            static bool appOpen = true;
            static bool useStartUI = false;
            static string currentInput = "";
            static Timer aTimer = new System.Timers.Timer();
            static void Main(string[] args)
            {
                Console.WriteLine("Main - " + DateTime.Now.ToString("HH:mm:ss tt"));
                aTimer.Elapsed += new ElapsedEventHandler(DrawClock);
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
                while (appOpen) // to keep the application running and give a possible exit - will expand this
                {
                    DrawUI();
                }
            }
            #region UI region
            static void DrawClock(object source, ElapsedEventArgs e)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("DrawClock - " + DateTime.Now.ToString("HH:mm:ss     tt"));
                Console.SetCursorPosition(0, 7);
            }
            static void DrawUI()
            {
                Debug.WriteLine("currentInput = " + currentInput);
                if (currentInput == "A" || currentInput == "a")
                {
                    useStartUI = true;
                }
                else if (currentInput == "B" || currentInput == "b")
                {
                    useStartUI = false;
                }
                if (useStartUI)
                {
                    DisplayStartUI();
                }
                else
                {
                    DisplayCurrentUI();
                }
            }
            private static void DisplayStartUI()
            {
                CleanUI();
                Console.WriteLine("DisplayStartUI");
                Console.WriteLine("Press 'B' to switch to CurrentUI");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("You pressed {0}", keyPressed.KeyChar);
                currentInput = keyPressed.KeyChar.ToString();
                if (keyPressed.KeyChar.ToString() == "b")
                {
                    DrawUI();
                }
            }
            private static void DisplayCurrentUI()
            {
                CleanUI();
                Console.WriteLine("DisplayCurrentUI");
                Console.WriteLine("Press 'A' to switch to StartUI");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("You pressed {0}", keyPressed.KeyChar);
                currentInput = keyPressed.KeyChar.ToString();
                if (keyPressed.KeyChar.ToString() == "a")
                {
                    DrawUI();
                }
            }
            #endregion
            #region functional methods
            public static void CleanUI()
            {
                Console.SetCursorPosition(0, 5);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 6);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 7);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 5);
            }
            public static void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            #endregion
        }
    }
