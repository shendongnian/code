    public abstract class SecureAction
    {
        public void PerformAction();
    }
    public class UpdateRecords : SecureAction
    {
        public void PerformAction()
        {
            //code to do the update
        }
    }
    public class DoesNotHavePermissionAction : SecureAction
    {
        public void PerformAction()
        {
            //code to handle missing permissions
        }
    }
    public class SecureActionFactory
    {
        public void GetUpdateRecordsAction(User user)
        {
            if(user.HasPermissions(Actions.UpdateRecord)) {return new UpdateRecordsAction();}
    
            return new DoesNotHavePermissionAction();
        }
    }
