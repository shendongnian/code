        public string decoder(string data)
        {
            string b64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
            char o1, o2, o3;
            int h1, h2, h3, h4, bits, i = 0;
            string enc = "";
            do
            {
                h1 = b64.IndexOf(data.Substring(i++, 1));
                h2 = b64.IndexOf(data.Substring(i++, 1));
                h3 = b64.IndexOf(data.Substring(i++, 1));
                h4 = b64.IndexOf(data.Substring(i++, 1));
                bits = h1 << 18 | h2 << 12 | h3 << 6 | h4;
                o1 = (char)(bits >> 16 & 0xff);
                o2 = (char)(bits >> 8 & 0xff);
                o3 = (char)(bits & 0xff);
                if (h3 == 64) enc += new string(new char[] { o1 });
                else if (h4 == 64) enc += new string(new char[] { o1, o2 });
                else enc += new string(new char[] { o1, o2, o3 });
            } while (i < data.Length);
            return enc;
        }
        public string d(int key, string data)
        {
            int i;
            string strInput = decoder(data);
            StringBuilder strOutput = new StringBuilder("");
            int intOffset = (key + 112) / 12;
            for (i = 4; i < strInput.Length; i++)
            {
                int thisCharCode = strInput[i];
                char newCharCode = (char)(thisCharCode - intOffset);
                strOutput.Append(newCharCode);
            }
            return strOutput.ToString();
        }
