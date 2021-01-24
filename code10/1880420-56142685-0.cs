     List<string> objList = new List<string>();
            objList.Add("0:0:10");
            objList.Add("0:0:10");
            objList.Add("1:1:10");
            objList.Add("0:3:10");
            TimeSpan CurrTime;
            DateTime CurrDate = new DateTime();
            foreach (var item in objList)
            {
                if (TimeSpan.TryParse(item, out CurrTime))
                {
                    CurrDate = CurrDate.Add(CurrTime);
                }
            }
            Console.Write(CurrDate.ToString());
