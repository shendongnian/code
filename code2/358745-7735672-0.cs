            //utf-8 Single Byte Sequence input
            string str = "à¤¤";
            int i = 0;
            byte[] data=new byte[3];
            foreach (char c in str)
            {
                string tmpstr = String.Format("{0:x2}", (int)c);
                data[i] = Convert.ToByte(int.Parse(tmpstr, System.Globalization.NumberStyles.HexNumber));
                i++;
            }
            
            //utf-8 3-Byte Sequence Output now stp contains "त".
            string stp = Encoding.UTF8.GetString(data);
