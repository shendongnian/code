       string[] rows = File.ReadAllLines(sourcefile);
            List<string> nlist = new List<string>();
            foreach (var row in rows)
            {
                string[] elements = row.Split(' ');
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements.GetValue(i).ToString() == "A111")
                    {
                        elements.SetValue("A555", i);
                      
                    }
                    nlist.Add(elements[i]);
                    
                }
                string hex = string.Join(" ",nlist);
                var destFile = targetPath.FullName + "\\" + "output.txt";
                File.WriteAllText(destFile, hex);
            }         
