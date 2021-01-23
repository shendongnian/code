            List<string> files = new List<string>();
            files.Add(@"C:\Users\Admin\Documents\report2011.docx: My Report 2011");
            files.Add(@"C:\Users\Admin\Documents\newposter.docx: Dinner Party Poster 08");
            files.Add(@"C:\Users\Admin\Documents\newposter.docx: Dinner Party: 08");
            int lastColon;
            string filename;
            foreach (string s in files)
            {
                bool isFilePath = false;
                filename = s;
                while (!isFilePath)
                {
                    lastColon = filename.LastIndexOf(":");
                    if (lastColon > 0)
                    {
                        filename = filename.Substring(0, lastColon);
                        if (File.Exists(filename))
                        {
                            Console.WriteLine(filename);
                            isFilePath = true;
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", s);
                    }
                }
            }
