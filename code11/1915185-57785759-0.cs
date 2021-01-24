            string PointCode, words;
            int length = 4;
            int strLength = value.Length;
            int strCount = (strLength + length - 1) / length;
            string[] result = new string[strCount];
            char[] charcters = new char[strCount];
            for (int i = 0; i < strCount; ++i)
            {
                
                result[i] = value.Substring(i * length, Math.Min(length, strLength));
                strLength -= length;
                                             
                //Swap the bytes from UTF16 LE to UTF16 BE
                if (result[i].Length == 4)
                {
                    string PointCode1 = result[i].Substring(0, 2);
                    string PointCode2 = result[i].Substring(2, 2);
                    PointCode = PointCode2 + PointCode1;
                    charcters[i] = (char)Int16.Parse(PointCode, System.Globalization.NumberStyles.HexNumber);
                                        
                }
                else
                {
                    PointCode = "00" + result[i];
                    charcters[i] = (char)Int16.Parse(PointCode, System.Globalization.NumberStyles.HexNumber);
                                        
                }
                               
                
            }
            words = (string.Join("", charcters));
            return words;
 
