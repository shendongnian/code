    static List<Email> getList(ref string Path, string type)
            {
    
                exceptionList = new List<Email>();
                string[] jsonFileList = Directory.GetFiles(Path, type + "_*.json");
                if (jsonFileList.Length > 0)
                {
                    //read json file
                    foreach (string file in jsonFileList)
                    {
                        if (File.Exists(file))
                        {
                            List.Add(JsonConvert.DeserializeObject<ExceptionEmail>(File.ReadAllText(file)));
    
                            File.Delete(file);
                        }
                    }
                }
                return exceptionList;
            }
