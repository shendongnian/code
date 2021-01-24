       DateTime fromDate = DateTime.Now.AddHours(-10);
                DateTime toDate = DateTime.Now;
                DirectoryInfo directory = new DirectoryInfo(@"\\ServerName\SharedFolder\");
                var files = directory.GetFiles("*.*")  //add this.--
                            .Where(file => file.LastWriteTime >= fromDate && file.LastWriteTime <= toDate);
                foreach (var file in files)
                {
                    // add this.
                    if (file.Name != "Thumbs.db" && file.Name.StartsWith("~$") == false && file.Name.ToLower().Contains(".xml") == false)
                    {
                        string filename = file.Name.ToString();
                        Console.WriteLine(filename);
                    }
                }
