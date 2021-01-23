    [AccessAttribute(Roles.Administrator)]
    class AdminForm : BaseForm { }
    abstract class BaseForm
    {
        protected override void OnLoad(EventArgs e)
        {
            CheckAccess(); //check current user against attribute of form
 
            base.OnLoad(e);
        }
    }
    enum Roles
    {
       Administrator,
       User
    }
    class AccessAttribute : Attribute { }
