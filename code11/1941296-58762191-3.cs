    public static List<char> GetRange(string input)
    {
        input = input.Replace("[", "").Replace("]", "");
        var parts = input.Split(',');
        var range = new List<char>();
        foreach (var part in parts)
        {
            var ends = part.Split('-');
            if (ends.Length == 1)
            {
                range.Add(ends[0][0]);
            }
            else if (char.IsDigit(ends[0][0]))
            {
                var start = Convert.ToInt32(ends[0][0]);
                var end = Convert.ToInt32(ends[1][0]);
                var count = end - start + 1;
                range.AddRange(Enumerable.Range(start, count).Select(c => (char) c));
            }
            else
            {
                var start = (int) ends[0][0];
                var last = (int) ends[1][0];
                var end = last < start ? 'z' : last;
                range.AddRange(Enumerable.Range(start, end - start + 1)
                    .Select(c => (char) c));
                if (last < start)
                {
                    range.AddRange(Enumerable.Range('A', last - 'A' + 1)
                        .Select(c => (char) c));
                }
            }
        }
        return range;
    }
