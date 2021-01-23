     public static string MyStringFormat(string formatString, params object[] args)
        {
            var regex = new Regex("{([0-9]*)}");
            return regex.Replace(formatString,m =>
                               {
                                   int index = int.Parse(m.Groups[1].Value);
                                   if(index<args.Length)
                                      return args[index].ToString();
                                   return String.Empty;
                               });
        }
