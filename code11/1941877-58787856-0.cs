private Random r = new Random();
//The chars that you don't want to be included like white spaces commas..etc.
private int[] skipCodes = new[] { 32, 39, 44, 96, 124 };
private string spec = "@&#><-[]Łł$ß";
private string GeneratePassword(
    int length, 
    bool useLowercase, 
    bool useUppercase, 
    bool useDigits, 
    bool useSpecialChars, 
    bool useUserDefined, 
    string userDefined
    )
{
    if (!useLowercase && !useUppercase && !useDigits && !useSpecialChars && !useUserDefined)
        return "";
    StringBuilder sb = new StringBuilder(length * 2);
    int ri = 0;
    int code = 0;            
    while (sb.Length < length)
    {
        code = 0;
        ri = r.Next(0, 5); //get a random option.
        switch (ri)
        {
            case 0:
                {
                    if (useLowercase)
                        code = r.Next(97, 123);
                    break;
                }
            case 1:
                {
                    if (useDigits)
                        code = r.Next(48, 58);
                    break;
                }
            case 2:
                {
                    if (useUppercase)
                        code = r.Next(65, 91);
                    break;
                }
            case 3:
                {
                    if (useSpecialChars)
                    {
                        if (sb.Length % 4 == 0)
                            code = r.Next(33, 48);
                        else if (sb.Length % 4 == 1)
                            code = r.Next(58, 65);
                        else if (sb.Length % 4 == 2)
                            code = r.Next(91, 96);
                        else if (sb.Length % 4 == 3)
                            code = r.Next(123, 126);
                        if (skipCodes.Contains(code))
                            code = 0;
                    }
                    break;
                }
            case 4:
                {
                    if (useUserDefined && !string.IsNullOrEmpty(userDefined))
                    {
                        code = (int)Convert.ToChar(userDefined.Substring(r.Next(0, userDefined.Length), 1));
                    }
                    break;
                }
        }
        if (code > 0)
            sb.Append((char)code);
    }
    return sb.ToString();
}
Then you can generate a password as follow:
string pass = GeneratePassword(12, true, true, true, false, true, spec);
Console.WriteLine(pass);
Or call it several times to generate a specific pattern. Tweak it to meet your needs.
Good luck.
