            string len = "SSM";
            StringBuilder Nlen = new StringBuilder();
            for (int i = 0; i < len.Length; i++)
            {
                if ((i+1) < len.Length && len[i] == len[i + 1])
                {
                    Nlen.Append(len[i]);
                    Nlen.Append('X');
                }
                else
                {
                    Nlen.Append(len[i]);
                }
            }
