            string s = "FF";
            byte b;
           
            if (byte.TryParse(s, NumberStyles.HexNumber, null, out b))
            {
                MessageBox.Show(b.ToString());  //255
            }
