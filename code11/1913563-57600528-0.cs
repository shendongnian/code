            static string Script(string strTag)
            {
                uint tag = uint.Parse(strTag);
                uint maxNumericTag = 0x0000FFFF;
                int minOldSchemeHighByteValue = 9;// old code 9 is 36th character in symboSpace
                string symbolSpace = "abcdefghijklmnopqrstuvwxyz0123456789";
                string results = "";
                if (tag <= maxNumericTag)
                {
                    results = strTag;
                }
                else
                {
                    if (minOldSchemeHighByteValue <= (tag >> 24))
                    {
                        results = strTag; //script is just converting an int to a string
                    }
                    else
                    {
                        results =
                            symbolSpace.Substring((int)((tag >> 24) & 0x3F) - 1, 1) +
                            symbolSpace.Substring((int)((tag >> 18) & 0x3F) - 1, 1) +
                            symbolSpace.Substring((int)((tag >> 12) & 0x3F) - 1, 1) +
                            symbolSpace.Substring((int)(tag & 0x3F) - 1, 1);
                    }
                }
                return results;
            }
