            Dictionary<int, string> userProjects = new Dictionary<int, string>
            {
                { 1, "User1" },
                { 2, "User1" },
                { 3, "User2" },
                { 4, "User3" },
                { 5, "User1" },
                { 6, "User2" },
                { 7, "User2" },
                { 8, "User1" },
            };
            Dictionary<string, int> limits = new Dictionary<string, int>
            {
                { "User1", 3 },
                { "User2", 2 },
                { "User3", 2 },
            };
            var ranked = 
                from up in userProjects
                join l in limits on up.Value equals l.Key
                orderby up.Value
                where (from upr in userProjects
                       where upr.Value == up.Value && upr.Key <= up.Key
                       select upr).Count() <= l.Value
                select up;
