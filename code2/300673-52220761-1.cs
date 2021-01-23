    private static int IpCompare(string x, string y)
        {
            string ip1 = x + '.', ip2 = y + '.';
            string xSection = "", ySection = "";
            for (int i = 0; i < ip1.Length && i < ip2.Length; i++)
            {
                if (ip1[i] == '.' && ip2[i] == '.')
                {
                    if (xSection != ySection)
                        return int.Parse(xSection) - int.Parse(ySection);
                    xSection = "";
                    ySection = "";
                }
                else if (ip1[i] == '.') return -1;
                else if (ip2[i] == '.') return 1;
                else
                {
                    xSection += ip1[i];
                    ySection += ip2[i];
                }
            }
            return 0;
        }
    
