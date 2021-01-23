    public static string GetCommonStart(string fp1, string fp2, string fp3)
    {
        int idx = 0;
        int minLength = Math.Min(Math.Min(fp1.Length, fp2.Length), fp3.Length);
        while (idx < minLength && fp1[idx] == fp2[idx] && fp2[idx] == fp3[idx])
           idx++;
        return fp1.Substring(0, idx);
    }
