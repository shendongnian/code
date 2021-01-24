    string s = Convert.ToString(-3, 2);
    // assuming the int is always representable by 24 bits two's complement
    if (s.Length < 24) { // alternatively, check integer is positive
        s = s.PadLeft(24, '0');
    } else if (s.Length > 24) { // alternatively, check integer is negative
        s = s.Substring(8);
    }
