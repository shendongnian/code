    static void Main(string[] args)
    {
        var input = @"CNTYTestingTesting//This is some more test CNTY1234//And some moreCNTYWhat is this?//";
        var sb = new StringBuilder();
        int inCnty = -1;
        for (int i = 0; i < input.Length; i ++)
        {
            // Test for start
            if (i < input.Length - 4)
            {
                if (input.Substring(i, 4) == "CNTY")
                {
                    inCnty = i + 4; // Index of first CNTY
                }
            }
            // Test for end
            if (i < input.Length - 1)
            {
                if (input.Substring(i, 2) == @"//")
                {
                    inCnty = -1; // Reset
                }
            }
            // Test if we are in the segment
            if (i >= inCnty && inCnty > 0)
            {
                // Outside string
                sb.Append(input[i]);
            }
        }
        var output = sb.ToString();
        Console.WriteLine(output);
        Console.Read();
    }
