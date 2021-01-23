        [DllImport("kernel32.dll")] static extern bool AllocConsole();
        [DllImport("kernel32.dll")] static extern bool AttachConsole(int pw);
        private static bool _hasConsole, _keepConsoleOpen;
        static private void EnsureConsole()
        {
            _hasConsole      =  _hasConsole || AttachConsole(-1);
            _keepConsoleOpen = !_hasConsole || _keepConsoleOpen;
            _hasConsole      =  _hasConsole || AllocConsole();
        }
        [STAThread]
        private static void Main(string[] args)
        {
              EnsureConsole();
              // the usual stuff -- your program
              if (_keepConsoleOpen)
              {
                  Console.WriteLine("(press enter)...");
                  Console.Read();
              }
        }
 
