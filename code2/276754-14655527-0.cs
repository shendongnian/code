        private String stringclear(String str)
        {
            String tuslar = "qwertyuopasdfghjklizxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM._0123456789 :;-+/*@%()[]!\nüÜğĞİışŞçÇöÖ"; // also you can add utf-8 chars
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (tuslar.Contains(str[i].ToString()))  //from tuslar string. non special chars
                    sb.Append(str[i]);
                if (str[i] == (char)13) // special char (enter key)
                    sb.Append(str[i]);
            }
            return sb.ToString();
        }
