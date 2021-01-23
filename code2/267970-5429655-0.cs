    Dictionary<string, int> s = new Dictionary<string, int>();
            s.Add("Test1", 123);
            s.Add("Test2", 321);
            
            foreach(KeyValuePair<string,int> temp in s)
            {
                DropDownList1.Items.Add(new ListItem(string.Format("{0} - Count: {1}", temp.Key, temp.Value),temp.Value.ToString()));
            }
