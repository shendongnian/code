     using System.Text.RegularExpressions
        public static void AddAStringtoAllTextFiles()
        {
            try
            {
                string path = @"C:\Users\ur\Desktop\TestFiles\";
                var fileEntries = Directory.GetFiles(path);
                int indexPosition2InsertData=1;
                foreach (var entry in fileEntries)
                {
                    var lines = File.ReadAllLines(entry);
                    for (var index = 1; index < lines.Length; index++) //starting  from first row, leaving the header
                    {
                        var split= Regex.Split(lines[index].Trim(), @"\s{1,}"); //reading the line with space(s)
                        if(split.Length>1) checking if the row is not blank
                        {
                            var list = split.ToList(); //convert to list to insert
                            list.Insert(indexPosition2InsertData, "STRINGTOENTER"); //inserting at the index 1
                            lines[index] = string.Join("\t", list);
                        }
                    }
                    File.WriteAllLines(entry, lines);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
