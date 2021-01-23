    Regex rx = LikeToRegEx(emailToMatch);
    
    User[] qry = (from u in context.Users
                  where u.ApplicationName == pApplicationName
                  orderby u.Username
                  select u)
                 .ToArray()
                 .Where(u => rx.IsMatch(u.Email))
                 .ToArray();
    
     // -- LikeToRegEx : Converts SQL like match pattern to a regular expression -- 
     public Regex LikeToRegEx(string likestr, RegexOptions opt = RegexOptions.None)
     {
                likestr = likestr
                         .Replace("*", ".")
                         .Replace("+", ".")
                         .Replace("(", ".")
                         .Replace("[", ".")
                         .Replace("/", ".")
                         .Replace("\\", ".")
                         .Replace("^", ".")
                         .Replace("$", ".")
                         .Replace("_", ".")
                         .Replace("%", ".*");
    
                return new Regex(likestr, opt);
     }
