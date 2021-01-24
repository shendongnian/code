    static IEnumerable<object> RecursiveSplit(string s)
    {
        string num = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                i++;
                int start = i;
                for (int sub = 1; sub > 0; i++)
                {
                    if (s[i] == '(')
                        sub++;
                    else if (s[i] == ')')
                        sub--;
                }
                yield return RecursiveSplit(s.Substring(start, i - start - 1));
            }
            else if (s[i] == ';')
            {
                yield return num;
                num = "";
            }
            else
            {
                num += s[i];
            }
        }
        if (num != "")
            yield return num;
    }
