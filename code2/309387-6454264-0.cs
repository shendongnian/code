        string str = "8798dsfgsd98gs87£%%001912.43.36.";
        string result = string.Empty;
        foreach(char ch in str)
        {
            int i;
            try
            {
                i = Convert.ToInt16(ch);
                result += i.ToString();
            }
            catch { }
        }
