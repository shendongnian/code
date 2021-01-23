    public class SemiNumericComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            if (int.TryParse(s1, out var i1) && int.TryParse(s2, out var i2))
            {
                if (i1 > i2)
                {
                    return 1;
                }
                if (i1 < i2)
                {
                    return -1;
                }
                if (i1 == i2)
                {
                    return 0;
                }
            }
            var text1 = SplitCharsAndNums(s1);
            var text2 = SplitCharsAndNums(s2);
            if (text1.Length > 1 && text2.Length > 1)
            {
                for (var i = 0; i < Math.Max(text1.Length, text2.Length); i++)
                {
                    if (text1[i] != null && text2[i] != null)
                    {
                        var pos = Compare(text1[i], text2[i]);
                        if (pos != 0)
                        {
                            return pos;
                        }
                    }
                    else
                    {
                        //text1[i] is null there for the string is shorter and comes before a longer string.
                        if (text1[i] == null)
                        {
                            return -1;
                        }
                        if (text2[i] == null)
                        {
                            return 1;
                        }
                    }
                }
            }
            return string.Compare(s1, s2, true);
        }
        private string[] SplitCharsAndNums(string text)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < text.Length - 1; i++)
            {
                if ((!char.IsDigit(text[i]) && char.IsDigit(text[i + 1])) ||
                    (char.IsDigit(text[i]) && !char.IsDigit(text[i + 1])))
                {
                    sb.Append(text[i]);
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
            sb.Append(text[text.Length - 1]);
            return sb.ToString().Split(' ');
        }
    }
