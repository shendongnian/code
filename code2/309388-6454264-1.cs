        string str = "8798dsfgsd98gs87£%%001912.43.36.";
        string result = string.Empty;
        for (int j = 0; j < str.Length; j++)
        {
            int i;
            try
            {
                i = Convert.ToInt16(str[j].ToString());
                result += i.ToString();
            }
            catch { }
        }
