    static string StringsADD(string s1, string s2)
    {
        int l1 = s1.Count();
        int l2 = s2.Count();
        int[] l3 = { l1, l2 };
        int minlength = l3.Min();
        int maxlength = l3.Max();
        int komsu = 0;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < maxlength; i++)
        {
            Int32 e1 = Convert.ToInt32(s1.PadLeft(maxlength, '0').ElementAt(maxlength - 1 - i).ToString());
            Int32 e2 = Convert.ToInt32(s2.PadLeft(maxlength, '0').ElementAt(maxlength - 1 - i).ToString());
            Int32 sum = e1 + e2 + komsu;
            if (sum >= 10)
            {
                sb.Append(sum - 10);
                komsu = 1;
            }
            else
            {
                sb.Append(sum);
                komsu = 0;
            }
            if (i == maxlength - 1 && komsu == 1)
            {
                sb.Append("1");
            }
        }
        return new string(sb.ToString().Reverse().ToArray());
    }
