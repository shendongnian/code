       private void update(String s)
        {
            int exp = decode(s.Substring(1, 5));
            exp += 20000000;
            int dt = decode(s.Substring(5, 11));
            int op = decode(s.Substring(11, 15));
            int hi = decode(s.Substring(15, 19));
            int lo = decode(s.Substring(19, 23));
            int cl = decode(s.Substring(23, 27));
            int v = decode(s.Substring(27, 33));
            int ni = decode(s.Substring(33, 39));
            //append(""+exp,dt, op/100.0f, hi/100.0f, lo/100.0f, cl/100.0f, v, ni);
        }
        private int decode(String s)
        {
            int n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int c = (int)s[i];
                if (c >= (int)'A' && c <= (int)'Z')
                    c = c - (int)'A';
                else if (c >= (int)'a' && c <= (int)'z')
                    c = c - (int)'a' + 26;
                else if (c >= (int)'0' && c <= (int)'9')
                    c = c - (int)'0' + 52;
                else if (c == (int)'$')
                    c = 62;
                else if (c == (int)'.')
                    c = 63;
                else
                    c = 0;
                n <<= 6;
                n += c;
            }
            return n;
        }
