        using System.Linq;
        using System.Text.RegularExpressions;
                                    
        public int ContainedNum(string s)
        {
            var match = Regex
               .Match(s, (@"JLPT N(\d{1})"))
               .Groups
               .Cast<Group>()
               .Skip(1) // the first match is the entire string not the group
               .Single()
               .Value;
            var num = int.Parse(match);
            return num;
        }
