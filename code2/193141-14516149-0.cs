            char[] carr = str.ToCharArray();
            for (int i = 0; i < carr.Length; i++)
            {
                if (char.IsLetter(carr[i]))
                {
                    carr[i] = char.IsUpper(carr[i]) ? char.ToLower(carr[i]) : char.ToUpper(carr[i]);
                }
            }
            str = new string(carr);
