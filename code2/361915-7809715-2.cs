            var list = new string[][]
                {
                    new string[] { "Text", "A", "B", "C", "D" }, 
                    new string[] { "None", "Z", "C" },
                    new string[] { "FullText", "1", "2", "3" }, 
                    new string[] { "FullMatch", "0", "A", "C", "Z" },
                    new string[] { "Ooops", "Nothing", "Here" },
                };
            string[][] newlist = list.Where(item => item[0].Equals("Text") 
                || item[0].Equals("FullText") 
                || item[0].Equals("FullMatch")).ToArray();
            // now display all data...
            foreach (string[] row in newlist)
            {
                Console.Write("Row: ");
                foreach (string item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
