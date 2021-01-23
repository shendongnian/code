            var strFileName = DisplayFile("choose file 1", "*.txt", null);
            var strFileName2 = DisplayFile("choose file 2", "*.txt", null);
            StreamReader srInputOne = File.OpenText(strFileName);
            StreamReader srInputTwo = File.OpenText(strFileName2);
            StreamWriter swOutput = new StreamWriter(@"U:\test\ThirdFile.txt");
            Hashtable oneHash = new Hashtable();
            Hashtable twoHash = new Hashtable();
            List <string> recOne = new List<string>();
            List<string> recNew = new List<string>();
            while (srInputTwo.Peek() > -1)
            {
                string line = srInputTwo.ReadLine();
                string[] vals = line.Split(' ');
                twoHash.Add(vals[0], vals[0]);
            }
            srInputTwo.Close();
            while (srInputOne.Peek() > -1)
            {
                string line = srInputOne.ReadLine();
                string[] parts = line.Split(' ');
                if(!twoHash.ContainsKey(parts[1]) && parts[0] == "1")
                {
                    swOutput.WriteLine(line);
                }
                else if (!twoHash.ContainsKey(parts[1]) && parts[0] == "1")
                {
                    swOutput.WriteLine(line);
                }
                else
                {
                    var join = string.Empty;
                    for (int i = 2; i < parts.Length; i++)
                    {
                        join = join + parts[i];
                    }
                    if (parts[1].Contains('A'))
                    {
                        join = join + " T";
                    }
                    else
                    {
                        join = join + " B";
                    }
                    if (!oneHash.ContainsKey(parts[1]))
                    {
                        oneHash.Add(parts[1], join);
                    }
                }
            }
            srInputOne.Close();
            srInputTwo = File.OpenText(strFileName2);
            while(srInputTwo.Peek() > -1)
            {
                string line2 = srInputTwo.ReadLine();
                string[] parts2 = line2.Split(' ');
                string join2 = string.Empty;
                for (int i = 1; i < parts2.Length; i++)
                {
                    join2 = join2 + " " + parts2[i];
                }
                if (oneHash.ContainsKey(parts2[0]))
                {
                    if (join2.Contains(','))
                    {
                        for (int j = 1; j < parts2.Length; j++)
                        {
                            swOutput.WriteLine("1 " + parts2[j].Trim(',') + " " + oneHash[parts2[0]].ToString());
                        }
                    }
                    else
                    {
                        swOutput.WriteLine("1" + join2 + " " + oneHash[parts2[0]].ToString());
                    }
                }
            }
            srInputTwo.Close();
            swOutput.Close();
       
