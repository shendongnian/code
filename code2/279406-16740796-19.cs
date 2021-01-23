    User[] qry = (from u in context.Users
                  where u.ApplicationName == pApplicationName
                     && context.RegExpLike(u.Username, usernameToMatch, (int)RegexOptions.IgnoreCase)
                  orderby u.Username
                  select u)
                 .Skip(startIndex)
                 .Take(pageSize)
                 .ToArray();
