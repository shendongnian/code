    var strFileName = DisplayFile("choose file 1", "*.txt", null);
            var strFileName2 = DisplayFile("choose file 2", "*.txt", null);
            StreamReader srInputOne = File.OpenText(strFileName);
            Hashtable oneHash = new Hashtable();
            while (srInputOne.Peek() > -1)
            {
                string line = srInputOne.ReadLine();
                string[] parts = line.Split(' ');
                var join = string.Empty;
                for (int i = 2; i < parts.Length; i++)
                {
                    join = join + parts[i];
                }
                if (parts[1].Contains('A'))
                {
                    join = join + " T";
                }
                oneHash.Add(parts[1], parts[0] + " " + join);
            }
            srInputOne.Close();
            StreamReader srInputTwo = File.OpenText(strFileName2);
            StreamWriter swOutput = new StreamWriter(@"U:\test\ThirdFile.txt");
            while(srInputTwo.Peek() > -1)
            {
                string line2 = srInputTwo.ReadLine();
                string[] parts2 = line2.Split(' ');
                string join2 = string.Empty;
                for (int i = 1; i < parts2.Length; i++)
                {
                    join2 = join2 + parts2[i];
                }
                if(!join2.Contains(','))
                {
                    string temp = oneHash[parts2[0]].ToString();
                 swOutput.WriteLine(temp.Substring(0,temp.IndexOf(' '))+ " "+join2+ " "+temp.Substring(temp.IndexOf(' ')));
                }
                else if(oneHash.ContainsKey(parts2[0]))
                {
                    for(int j = 1; j < parts2.Length; j++)
                    {
                        string temp = oneHash[parts2[0]].ToString();
                        swOutput.WriteLine(temp.Substring(0, temp.IndexOf(' ')) + " " + parts2[j].Trim(',') + " " + temp.Substring(temp.IndexOf(' ')));
                    }
                }
            }
            srInputTwo.Close();
            swOutput.Close();
