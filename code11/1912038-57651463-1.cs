        protected void Page_Load(object sender, EventArgs e)
        {
            List<Role> roles = new List<Role>();
            Role accountantRole = new Role("Accountant", 1);
            accountantRole.SubRoles.Add(new SubRole(SubRoleType.Red.ToString(), (int)SubRoleType.Red));
            accountantRole.SubRoles.Add(new SubRole(SubRoleType.Orange.ToString(), (int)SubRoleType.Green));
            accountantRole.SubRoles.Add(new SubRole(SubRoleType.Green.ToString(), (int)SubRoleType.Orange));
            roles.Add(accountantRole);
            Role managmentRole = new Role("Accountant Managment", 2);
            managmentRole.SubRoles.Add(new SubRole(SubRoleType.Red.ToString(), (int)SubRoleType.Red));
            managmentRole.SubRoles.Add(new SubRole(SubRoleType.Orange.ToString(), (int)SubRoleType.Green));
            managmentRole.SubRoles.Add(new SubRole(SubRoleType.Green.ToString(), (int)SubRoleType.Orange));
            roles.Add(managmentRole);
            foreach (var role in roles)
                AddRoleToDropDownList(ddlRole, role);          
        }
        private void AddRoleToDropDownList(DropDownList list, Role role)
        {
            foreach (var subRole in role.SubRoles)
            {
                ListItem item = new ListItem(subRole.Name, subRole.Name);
                item.Attributes["data-category"] = role.Name;
                list.Items.Add(item);
            }
        }    
