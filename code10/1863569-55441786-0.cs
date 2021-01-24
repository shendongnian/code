    public class MainGame
    {
        public string Connected_IP = " ";
        public short Is_Connected = 0;
        static MainGame mg = null; // instantiated in Main()
        static void Main()
        {
            mg = new MainGame(); // this instance will be worked with throughout the program
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainConsole(mg)); // pass our reference of MainGame to MainConsole
        }
        public string checkCommands(string command) // no "ref" on the return type
        {
            IP_DataBase ips = new IP_DataBase();
            /*checking for ips in the list*/
            string[] dump;
            if (command.Contains("connect"))
            {
                dump = command.Split(' ');
                for (int i = 0; i < ips.IPS.Length; i++)
                {
                    if (dump[1] == ips.IPS[i])
                    {
                        Connected_IP = dump[1];
                        Is_Connected = 1;
                        break;
                    }
                    else
                    {
                        Connected_IP = "Invalid IP";
                        Is_Connected = 0;
                    }
                }
            }
            else if (command.Contains("quit")) /*disconnect command*/
            {
                Connected_IP = "Not Connected";
                Is_Connected = 0;
            }
            return Connected_IP;
        }
    }
