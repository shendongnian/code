    string s = "this - is a string   - with hyphens  -     in it";
    string[] groups = s.Replace(" ", "-")
                       .Split(
                           new[] { '-' },
                           StringSplitOptions.RemoveEmptyEntries
                      );
    string t = String.Join("-", groups);        
