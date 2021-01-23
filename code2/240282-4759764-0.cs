    var newSettings = new List<SettingsTableRecord>();
    foreach (var userGuid in usersWithoutInfo) {
        if(!context.SettingsTableRecords.Any(u=>u.UserGuid.Equals(userGuid)){
            //do work to crate records, such as
            newSettings.Add(new SettingsTableRecord {UserGuid = userGuid, Email="Hi!"});
        }
    }
    //insert the new records
    context.SettingsTableRecords.InsertAllOnSubmit(newSettings);
    context.SubmitChanges();
