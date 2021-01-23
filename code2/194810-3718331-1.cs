    List<string> list = new List<string>();
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string text = "";
                    while ((text = reader.ReadLine()) != null)
                    {
                        list.Add(text);
                    }
                    list.RemoveAt(0);
                    list.RemoveAt(0);
                }
