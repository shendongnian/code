    //  Encapsulate these fields if you want to be PC
    public class Roles {
        public bool PrimaryRole;
        public bool SecondaryRole;
    }
    public class RoleButton: Button {
        protected Roles buttonRoles;    
        ...
    }
    public class SharedPreRenderCommand : ICommand {
        public void ExecuteOnPreRender(WebControl control, Roles roles, EventArgs args) {
            //  Modify the Roles class, which the RoleButton or 
            //  RoleImageButton has a handle to
        }
    }
