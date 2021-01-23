    public static string NumAdd(int iOne, int iTwo)
        {
            char[] strOne = iOne.ToString().ToCharArray();
            char[] strTwo = iTwo.ToString().ToCharArray();
            string strReturn = string.Empty;
            for (int i = 0; i < strOne.Length; i++)
            {
                int iFirst = 0;
                if (int.TryParse(strOne[i].ToString(), out iFirst))
                {
                    int iSecond = 0;
                    if (int.TryParse(strTwo[i].ToString(), out iSecond))
                    {
                        strReturn += ((int)(iFirst + iSecond)).ToString();
                    }
                }
                // last one, add the remaining string
                if (i + 1 == strOne.Length)
                {
                    strReturn += iTwo.ToString().Substring(i+1); 
                    break;
                }
            }
            return strReturn;
        }
