            List<string> RtnList = new List<string>();
            foreach (string Line in ListDetails)
            {
                    if (line.StartsWith("d") && !line.EndsWith("."))
                    {
                        RtnList.Add(line.Split(' ')[line.Split(' ').Length - 1] );
                        
                    }
            }
