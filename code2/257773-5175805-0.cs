        static string command = "";
        static System.IO.Stream s;
        static bool quit = false;
        static byte[] buf = new byte[1];
        static void Main(string[] args)
        {
            s = Console.OpenStandardInput();
            s.BeginRead(buf, 0, 1, new AsyncCallback(s_Read), null);
            while (!quit)
            {
                // Do something instead of sleep
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Sleeping");
            }
            s.Close();
        }
        public static void s_Read(IAsyncResult target)
        {
            if (target.IsCompleted)
            {
                int size = s.EndRead(target);
                string input = System.Text.Encoding.ASCII.GetString(buf);
                if (input.EndsWith("\n") || input.EndsWith("\r"))
                {
                    if (command.ToLower() == "quit") quit = true;
                    Console.Write("Echo: " + command);
                    command = "";
                }
                else
                    command += input;
                s.BeginRead(buf, 0, 1, new AsyncCallback(s_Read), null);
            }
        }
