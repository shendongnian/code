    public class CodeComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xParts = x.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            var yParts = y.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < Math.Max(xParts.Length, yParts.Length); i++)
            {
                if (xParts.Length <= i)
                    return -1;
                if (yParts.Length <= i)
                    return 1;
                if (!int.TryParse(xParts[i], out var xInt) || !int.TryParse(yParts[i], out var yInt))
                {
                    var abcCompare = x.CompareTo(y);
                    if (abcCompare != 0)
                        return abcCompare;
                    continue;
                }
                if (xInt != yInt)
                    return xInt < yInt ? -1 : 1;
            }
            return x.CompareTo(y);
        }
    }
