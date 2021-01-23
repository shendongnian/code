    public class CodeComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xParts = x.Split(new char[] { '.' });
            var yParts = y.Split(new char[] { '.' });
            var partsLength = Math.Max(xParts.Length, yParts.Length);
            if (partsLength > 0)
            {
                for (var i = 0; i < partsLength; i++)
                {
                    if (xParts.Length <= i) return -1;// 4.2 < 4.2.x
                    if (yParts.Length <= i) return 1;
                    var xPart = xParts[i];
                    var yPart = yParts[i];
                    if (string.IsNullOrEmpty(xPart)) xPart = "0";// 5..2->5.0.2
                    if (string.IsNullOrEmpty(yPart)) yPart = "0";
                    if (!int.TryParse(xPart, out var xInt) || !int.TryParse(yPart, out var yInt))
                    {
                        // 3.a.45 compare part as string
                        var abcCompare = xPart.CompareTo(yPart);
                        if (abcCompare != 0)
                            return abcCompare;
                        continue;
                    }
                    if (xInt != yInt) return xInt < yInt ? -1 : 1;
                }
                return 0;
            }
            // compare as string
            return x.CompareTo(y);
        }
    }
