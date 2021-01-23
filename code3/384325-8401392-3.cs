    public class RegisterUserSaga : Handles<UserCreated>
    {
        public void Handle<UserCreated>(UserCreated evnt) {
            var tenantId = // you probably know how to find this
            var groupId =  // same here
            var command = new RegisterUserForTenant(evnt.UserId, tenantId, groupId);
            Bus.Send(command);
        }
    }
