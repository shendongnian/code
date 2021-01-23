            string s = "TopLeft";
            List<int> splits = new List<int>();
            for(int i=0; i<s.Length;i++)
                if(char.IsUpper(s[i]))
                    splits.Add(i);
            int splitstart = 0;
            foreach (int split in splits)
            {
                s.Substring(splitstart, split);
                splitstart = split;
            }
