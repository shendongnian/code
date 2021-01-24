    int index = -1
    @using (Html.BeginForm(actionName: "EditPermissions", controllerName: "Device", method: FormMethod.Post))
    {
    <table>
        @{
        foreach (var User in Model.Users)
        {
        index++
        var deviceUserPermission = Model.DeviceUserPermissions.FirstOrDefault(x => x.UserId == User.UserId) ?? new
        RulesEngine.DAL.DeviceUserPermission()
        { UserId = User.UserId, DeviceId = Model.DeviceId, PermissionId = 0 };
    
        var selectList = new List<SelectListItem>();
            foreach (var permission in Model.Permissions)
            {
            selectList.Add(new SelectListItem() { Text = permission.PermissionName, Value = permission.PermissionId,
            Selected = (permission.PermissionId == deviceUserPermission.PermissionId) });
            }
    
            <tr>
                <td>
                    @User.Description
                </td>
                <td>
                    @Html.DropDownListFor(m => m.SelectedDeviceUserPermissions.FirstOrDefault(x => x.UserId ==
                    Model.Users[index].UserId).PermissionId, selectList, htmlAttributes: null)
    
                </td>
            </tr>
    
            }
            }
    </table>
    <input type="submit" value="Save" />
}
