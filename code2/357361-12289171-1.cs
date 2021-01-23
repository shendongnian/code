    public static class EnumExt {
        public static string[] ToRanges(this List<int> ints) {
            if (ints.Count < 1) return new string[] { };
            ints.Sort();
            var lng = ints.Count;
            var fromnums = new List<int>();
            var tonums = new List<int>();
            for (var i = 0; i < lng - 1; i++) {
                if (i == 0)
                    fromnums.Add(ints[0]);
                if (ints[i + 1] > ints[i] + 1) {
                    tonums.Add(ints[i]);
                    fromnums.Add(ints[i + 1]);
                }
            }
            tonums.Add(ints[lng - 1]);
            return Enumerable.Range(0, tonums.Count).Select(
                i => fromnums[i].ToString() +
                    (tonums[i] == fromnums[i] ? "" : "-" + tonums[i].ToString())
            ).ToArray();
        }
    }
