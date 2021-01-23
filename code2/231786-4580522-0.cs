    string[] roles = {"role1", "role2" };
            string[] tempusers = new string[]{};
            List<string> users = new List<string>();
            foreach (string role in roles)
            {
                string[] usersInRole = Roles.GetUsersInRole(role);
                users =  tempusers.Union(usersInRole).ToList();
                tempusers = users.ToArray();
            }
            foreach (string user in users) { Response.Write(user + "<br/>"); }
