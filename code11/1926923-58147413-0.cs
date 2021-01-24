            public void CheckGender(string pnr)
            {
                string arr = pnr.Substring(9, 1);
                if (arr == "0")
                {
                    Console.WriteLine("Woman!!!");
                }
                else
                {
                    Console.WriteLine("Man!!!");
                }
            }
