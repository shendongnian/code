        b = new byte[4];
        b[0] = Byte.Parse(s.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
        string v = Encoding.UTF32.GetString(b);
        string w = "\x00af";
        if (v != w)
            MessageBox.Show("Diff [" + w + "] = [" + v + "] ");
        else
            MessageBox.Show("Same");
