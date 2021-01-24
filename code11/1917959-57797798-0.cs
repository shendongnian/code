	public class SelectedAppRoles
	{
		public int RoleID { get; set; }
	}
Then a new list
		public List<SelectedAppRoles> selectedRoles;
Then used the list instead of an array
foreach (var role in allRoles)
            {
                AssignedAppRoleDataList.Add(new AssignedAppRoleData
                {
                    RoleID = role.ID,
                    Role = role.RoleName,
                    Assigned = appRoles.Contains(role.ID)
					
				});
				if (appRoles.Contains(role.ID))
				{
					selectedRoles.Add(new SelectedAppRoles
					{
						RoleID = role.ID,
					});					
				}
			}
