    public static IList<double> Parse(string text)
    {
        List<double> list = new List<double>();
        if (text != null)
        {
            StringBuilder dbl = new StringBuilder(30); 
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'm')
                {
                    list.Add(double.Parse(dbl.ToString(), CultureInfo.InvariantCulture));
                    dbl.Length = 0;
                }
                else
                {
                    if ((text[i] != ' ') && (text[i] != '/'))
                    {
                        dbl.Append(text[i]);
                    }
                }
            }
        }
        return list;
    }
