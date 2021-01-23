     public static string ToRanges(this List<int> ints)
        {
            ints.Remove(0); // Note: Remove this if you like to include the Value 0
            if (ints.Count < 1) return "";
            ints.Sort();
            var lng = ints.Count;
            if (lng == 1)
                return ints[0].ToString();
            var fromnums = new List<int>();
            var tonums = new List<int>();
            for (var i = 0 ; i < lng - 1 ; i++)
            {
                if (i == 0)
                    fromnums.Add(ints[0]);
                if (ints[i + 1] > ints[i] + 1)
                {
                    tonums.Add(ints[i]);
                    fromnums.Add(ints[i + 1]);
                }
            }
            tonums.Add(ints[lng - 1]);
            
            string[] ranges = Enumerable.Range(0, tonums.Count).Select(
                i => fromnums[i].ToString() +
                    (tonums[i] == fromnums[i] ? "" : "-" + tonums[i].ToString())
            ).ToArray();
            if (ranges.Length == 1)
                return ranges[0];
            else
                return String.Join(",", ranges);
        }
