    string s = "book//title//page/section/para";
            s = s.Replace("//", "DOUBLE");
            s = s.Replace("/", "SINGLE");
            IList<int> doubleIndex = new List<int>();
            while (s.Contains("DOUBLE"))
            {
                int index = s.IndexOf("DOUBLE");
                s = s.Remove(index, 6);
                s = s.Insert(index, "//");
                doubleIndex.Add(index);
            }
            IList<int> singleIndex = new List<int>();
            while (s.Contains("SINGLE"))
            {
                int index = s.IndexOf("SINGLE");
                s = s.Remove(index, 6);
                s = s.Insert(index, "/");
                singleIndex.Add(index);
            }
            
