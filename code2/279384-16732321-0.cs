Hi, I've had the same problem, but managed to get rid of it.
I know it's slow but works, any optimization/bugfix hint will be welcomed :)
The code gathers the data first then processes, 
so you need to filter as much as you can before calling toarray() or buy more ram :)
hope it helps, 
enjoy
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
