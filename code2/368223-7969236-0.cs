    public class SetRole : NoSourceValueInjection
         {
             protected override void Inject(object target)
             {
                 dynamic t = target;
                 t.RoleName = Roles.GetRolesForUser(t.UserName).FirstOrDefault();
             }
         }
    
    uvm.InjectFrom(user)
       .InjectFrom<SetRole>();
