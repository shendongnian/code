    public static string FormatCode(string code)
    {
        int originalLength = code.Length;
        switch (originalLength)
        {
            case 8:
                string codeFormat = ...;
                code = ...;
                break;
            case 9:
                codeFormat = ...;
                code = ...;
                break;
            // ...
        while (code.Length < originalLength) {
            code = "0" + code;
        }
        return code;
    }
