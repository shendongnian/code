    [HttpPost]
        public JsonResult ReassignToDev(Array userIds)
        {
            var message = "";
            if (userIds == null)
            {
                message = "No Users to Change Roles Of";
            }
            if (userIds != null)
            {
                foreach (var user in userIds)
                { 
                    userRolesHelper.RemoveAllRoles(user.ToString());
                    userRolesHelper.AddUserToRole(user.ToString(), "Developer");
                    message = "Role Change Successful";
                }
            }
            return Json(message);
        }
