    static string MaskName(string name)
        {
            string maskedString = string.Empty;
            string[] names = name.Split(',');
            if (names.Length > 0)
            {
                maskedString = names[0] + ",";
            }
            if (names.Length > 1)
            {
                string[] arrName = names[1].Split(' ');
                foreach (string s in arrName)
                {
                    if (s.Length > 0)
                        maskedString += " " + s[0].ToString().PadRight(s.Length, 'X');
                }
            }
            return maskedString;
        }
