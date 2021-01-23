        public static List<string> FindUsersByRole(string[] roles)
        {
            var userList = roles.Select(role => Roles.GetUsersInRole(role))
                                .Aggregate((a, b) => a.Union(b).ToArray())
                                .Distinct()
                                .ToList();
            return userList;
        }
