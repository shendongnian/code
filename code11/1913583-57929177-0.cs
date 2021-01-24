         public static void AddClientCodetoAllTextFiles(string update_batch_with_clientcode, string batchfilepathtobeupdated)
        {      
         
            try
            {
                var fileEntries = Directory.GetFiles(@batchfilepathtobeupdated.Trim());
                              
                foreach (var entry in fileEntries)
                {
                    var lines = File.ReadAllLines(entry);
                                        
                    if (lines.Length > 1)
                    {
                        for (int i = 1; i < lines.Length - 1; i++)
                        {
                            var split = lines[i].Split('\t');
                            split[1] = update_batch_with_clientcode.Trim();
                            lines[i] = string.Join("\t", split);
                            File.WriteAllLines(entry, lines);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
