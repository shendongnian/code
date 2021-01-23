    static string BuildCommandLineFromArgs(params string[] args)
    {
        if (args == null)
            return null;
        string result = "";
    
        if (Environment.OSVersion.Platform == PlatformID.Unix 
    		|| 
    		Environment.OSVersion.Platform == PlatformID.MacOSX)
        {
            foreach (string arg in args)
            {
                result += (result.Length > 0 ? " " : "") 
                    + arg
                        .Replace(@" ", @"\ ")
                        .Replace("\t", "\\\t")
                        .Replace(@"\", @"\\")
                        .Replace(@"""", @"\""")
                        .Replace(@"<", @"\<")
                        .Replace(@">", @"\>")
                        .Replace(@"|", @"\|")
                        .Replace(@"@", @"\@")
                        .Replace(@"&", @"\&");
            }
        }
        else //Windows family
        {
            bool enclosedInApo, wasApo;
            string subResult;
            foreach (string arg in args)
            {
                enclosedInApo = arg.LastIndexOfAny(
    				new char[] { ' ', '\t', '|', '@', '^', '<', '>', '&'}) >= 0;
                wasApo = enclosedInApo;
                subResult = "";
                for (int i = arg.Length - 1; i >= 0; i--)
                {
                    switch (arg[i])
                    {
                        case '"':
                            subResult = @"\""" + subResult;
                            wasApo = true;
                            break;
                        case '\\':
                            subResult = (wasApo ? @"\\" : @"\") + subResult;
                            break;
                        default:
                            subResult = arg[i] + subResult;
                            wasApo = false;
                            break;
                    }
                }
                result += (result.Length > 0 ? " " : "") 
    				+ (enclosedInApo ? "\"" + subResult + "\"" : subResult);
            }
        }
    
        return result;
    }
