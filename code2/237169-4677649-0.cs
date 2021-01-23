            List<List<string>> list = new List<List<string>>();
            List<string> sublist = new List<string>();
            foreach (string element in originalList)
            {
                if (element.Contains("t"))
                {
                    list.Add(sublist);
                    sublist = new List<string>();
                }
                sublist.Add(element);
            }
            list.Add(sublist);
