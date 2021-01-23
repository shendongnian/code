    static double string_double(string s)
        {
            double temp = 0;
            double dtemp = 0;
            int b = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    i++;
                    while (i < s.Length)
                    {
                        dtemp = (dtemp * 10) + (int)char.GetNumericValue(s[i]);
                        i++;
                        b++;
                    }
                    temp = temp + (dtemp * Math.Pow(10, -b));
                    return temp;
                }
                else
                {
                    temp = (temp * 10) + (int)char.GetNumericValue(s[i]);
                }
            }
            return -1; //if somehow failed
        }
