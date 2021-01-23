                Dictionary<string, List<string>> dc = new Dictionary<string, List<string>>();
                int count = 0;
    
                foreach (string group in array)
                {
                    dc.Add("Group" + (++count), new List<string>());
                }
    
                //you can later retrieve the list from dictionary
                if (dc.ContainsKey("Group1"))
                {
                    List<string> list = dc["Group1"];
                    //and you can then use the list
                }
