    public static string ToRomanNumeral(this int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException("Please use a positive integer greater than zero.");
    
        StringBuilder sb = new StringBuilder();
        int remain = value;
        while (remain > 0)
        {
            if (remain >= 1000) { sb.Append("M"); remain -= 1000; }
            else if (remain >= 900) { sb.Append("CM"); remain -= 900; }
            else if (remain >= 500) { sb.Append("D"); remain -= 500; }
            else if (remain >= 400) { sb.Append("CD"); remain -= 400; }
            else if (remain >= 100) { sb.Append("C"); remain -= 100; }
            else if (remain >= 90) { sb.Append("XC"); remain -= 90; }
            else if (remain >= 50) { sb.Append("L"); remain -= 50; }
            else if (remain >= 40) { sb.Append("XL"); remain -= 40; }
            else if (remain >= 10) { sb.Append("X"); remain -= 10; }
            else if (remain >= 9) { sb.Append("IX"); remain -= 9; }
            else if (remain >= 5) { sb.Append("V"); remain -= 5; }
            else if (remain >= 4) { sb.Append("IV"); remain -= 4; }
            else if (remain >= 1) { sb.Append("I"); remain -= 1; }
            else throw new Exception("Unexpected error."); // <<-- shouldn't be possble to get here, but it ensures that we will never have an infinite loop (in case the computer is on crack that day).
        }
    
        return sb.ToString();
    }
