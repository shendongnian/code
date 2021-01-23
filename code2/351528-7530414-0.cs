        string a = "varA*varB%+Length('10%')";
        string[] b = a.Split('\'');
        string c = string.Empty;
        int i = 0;
        foreach (string sbs in b)
        {
            c += i%2==0?sbs.Replace("%","/100"):sbs;//for the every odd value of i "%" is within single quotes
            i++;
        }
