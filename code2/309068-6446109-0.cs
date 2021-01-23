            //code
            List<string> firstNames = new List<string>();
            firstNames.Add("John");
            firstNames.Add("Mary");
            firstNames.Add("Jane");
            StringBuilder sb = new StringBuilder();
            firstNames.Take(firstNames.Count - 1).ToList().ForEach(fn => AddString(fn, sb));
            sb.Append(", and " + firstNames.Last());
        //Helper Function
        public void AddString (string fn, StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                sb.Append(", ");
            }
            sb.Append(fn);
        }
