            // This is the string you get from the database:
            string dbEnumValues = "[[`notes`,1],[`logs`,1],[`superUser`,1]]";
            // We need to clean it up:
            dbEnumValues = dbEnumValues.Replace("[[", "").Replace("]]", "").Replace("],", "").Replace("`", "");
            // The line of code above will give us this: "notes,1[logs,1[superUser,1"
            // Now, we can split this into an array of strings:
            var enumValues = dbEnumValues.Split('[');
            List<PermissionValue> permissionValues = new List<PermissionValue>();
            // Next, let's loop over your array and split it further into 
            //    1) an option from Permission
            //    2) a true or false for IsActive
            foreach (var permission in enumValues)
            {
                string enumName = permission.Split(',')[0];
                string isActive = permission.Split(',')[1];
                PermissionValue permissionValue = new PermissionValue
                {
                    Permission = (Permission)Enum.Parse(typeof(Permission), enumName, true),
                    IsActive = isActive == "1" ? true : false
                };
                permissionValues.Add(permissionValue);
            }
