    public void Main()
        {
            string name = "bmsa1110_v1.1.zip";
            string varPattern = "####YYMM##XXX####";
            getVarPart(name, varPattern);
        }
    private string getVarPart(string name, string varPattern)
        {
            StringBuilder name_sb = new System.Text.StringBuilder(name);
            StringBuilder varPattern_sb = new System.Text.StringBuilder(varPattern);
            string YEAR = null;
            string MONTH = null;
            string DAY = null;
            string VERSION = null;
            for (int j = 0; j < varPattern_sb.Length; j++)
            {
                switch (varPattern_sb[j])
                {
                    case 'Y':
                        YEAR = YEAR + name_sb[j];
                        name_sb[j] = '#';
                        break;
                    case 'M':
                        MONTH = MONTH + name_sb[j];
                        name_sb[j] = '#';
                        break;
                    case 'D':
                        DAY = DAY + name_sb[j];
                        name_sb[j] = '#';
                        break;
                    case 'X':
                        VERSION = VERSION + name_sb[j];
                        name_sb[j] = '#';
                        break;
                    default:
                        break;
                }
            }
            string varPart = YEAR + MONTH + DAY + VERSION;
            return varPart;
        }
