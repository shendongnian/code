    [DllImport("user32.dll")]
        static extern bool GetCursorPos(out Point lpPoint);
        void StartGettingCursorPos()
        {
            Task.Run(new Action(() =>
            {
                while (true)
                {
                    GetCursorPos(out Point point);
                    Console.WriteLine($"X:{point.X}; Y:{point.Y}");
                    Thread.Sleep(20);
                }
            }));
        }
