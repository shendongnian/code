          SortedDictionary<int, string> dict = new SortedDictionary<int, string>();
          foreach (string s in my_array)
           {
                string[] splitArr=s.Split(':');
                dict.Add(Convert.ToInt32(splitArr[0]), splitArr[1]);
            }            
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, string> kvp in dict)
            {
                sb.Append(kvp.Value);
            }
            string final=sb.ToString();
