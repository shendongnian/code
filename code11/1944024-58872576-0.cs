            var s = "\u202atest";
            string s2 = null;
            byte[] bytes = new byte[s.Length * sizeof(char)];
            Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
            if (bytes[0] == 0x2a && bytes[1] == 0x20)
            {
                char[] c = new char[(bytes.Length - 2) / sizeof(char)];
                Buffer.BlockCopy(bytes, 2, c, 0, bytes.Length - 2);
                s2 = new string(c);
            }
            var c2 = s2.ToCharArray();
