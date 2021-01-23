        public static void Main(string[] args)
        {
            string stoptime = ConfigurationManager.AppSettings["Stoptime"];
            DateTime timeEnd = Convert.ToDateTime(stoptime);
            today = DateTime.Now;
            Console.WriteLine(today);
            for (int i = 0; i < 100000; i++)
            {
                id.Add(i.ToString());
            }
            foreach(string item in id)
            {
                today = DateTime.Now;
                if (timeEnd.CompareTo(today) >= 0)
                {
                    Console.CursorLeft = 0;
                    Console.Write(item + " " + today);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("break.");
                    break;
                }
            }
            Console.ReadKey();
        }
