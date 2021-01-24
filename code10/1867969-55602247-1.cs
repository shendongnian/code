    **Updated if u allow :)**
    public override string[] GetRolesForUser(string username)
        {
            //get all user data from user table for id based on user email
            int _user_id = Convert.ToInt32(db.users.Where(u => u.user_email == username).Select(i => i.user_id).FirstOrDefault());
            // Get role from user_has_role against user id
            var _role = db.user_has_role.Where(r => r.user_id == _user_id).Select(r => r.user_role.user_role_name);
            // store selected
            string[] roleName = _role.ToArray();
            if (roleName != null)
            {
                return roleName;
            }
            else
            {
                roleName = null;
                return roleName;
            }
        }
