            List<string> listItems = new List<string>();
            FileStream fs = new FileStream(@"c:\YourFile.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            int lineNo = 0;
            do {
                line = sr.ReadLine();
                if (line != null) {
                    listItems.Add(line);
                }
            } while (line != null);
            listItems.Sort();
            foreach(string s in listItems)
            {
                  yourListBox.Items.Add(s);
            }
