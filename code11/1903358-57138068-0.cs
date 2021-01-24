        private static void Main()
        {
            List<string> sCat = new List<string>();
            // add Categories for the Sheets
            sCat.Add("MD0");
            sCat.Add("MD1");
            sCat.Add("MD3");
            List<string> sLev = new List<string>();
            // add Levels for the Project
            sLev.Add("01");
            sLev.Add("02");
            sLev.Add("03");
            sLev.Add("R");
            string dash = "-";
            List<string> newList = new List<string>();
            for (int i = 0; i < sCat.Count; i++)
            {
                for (int j = 0; j < sLev.Count; j++)
                {
                    newList.Add(sCat[i] + dash + sLev[j]);
                }
            }
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
        }
