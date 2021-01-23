    db.Actions.Attach(myAction);
    db.ObjectStateManager.ChangeObjectState(myAction, EntityState.Modified);
    myAction.ActionUserNameAssignations.Clear();
    
    string[] sSelectedValues = CheckBoxListHelper.GetAllIds(collection, "CheckBox_UserName_", true).ToArray();
    foreach (string userName in sSelectedValues)
    {
       ActionUserNameAssignation assignation = new ActionUserNameAssignation { ActionId = myAction.ActionId, UserName = userName };
       myAction.ActionUserNameAssignations.Add(assignation);
    }
                    
    db.SaveChanges();
