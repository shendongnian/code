            string line;
            StreamReader sr = new StreamReader(@"C:\Users\J\Desktop\texts\First.txt");
            StreamReader sr2 = new StreamReader(@"C:\Users\J\Desktop\texts\Second.txt");
            
            List<String> fileOne = new List<string>();
            List<String> fileTwo = new List<string>();
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                if(line != "")
                {
                    fileOne.Add(line);
                }
            }
            sr.Close();
            while (sr2.Peek() >= 0)
            {
                line = sr2.ReadLine();
                if (line != "")
                {
                    fileTwo.Add(line);
                }
            }
            sr2.Close();
            var t = fileOne.Except(fileTwo);
            StreamWriter sw = new StreamWriter(@"C:\Users\justin\Desktop\texts\First.txt");
            
            foreach(var z in t)
            {
                sw.WriteLine(z);
            }
            sw.Flush();
