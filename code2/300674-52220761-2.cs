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
                    xSection = ""; // Start compare the next section
                    ySection = "";
                }
                else if (ip1[i] == '.') return -1; //The first section is smaller because it's length is smaller
                else if (ip2[i] == '.') return 1;
                else
                {
                    xSection += ip1[i];
                    ySection += ip2[i];
                }
            }
            return 0; 
            //If we would find any difference between any section it would already return something.
            //so that mean that both IPs are the same
       }
    
