     private Func<DataClasses.Activations, String> GetUserEmail(string username)
     {
        return System.Web.Security.Membership.GetUser(username).Email;
     }
     PaymentsDataContext data = new PaymentsDataContext();
            var q = from act in data.activations
                    where act.approved != true
                    orderby act.activationDate ascending
                    select new {activationID = act.activationID, userName = act.userName,
                    brokerName = act.broker.brokerName, existingAccount = act.existingAccount,
                    activationDate = act.activationDate, brokerUser = act.brokerUser, approved = act.approved, 
                    Email = GetUserEmail(act.username)};
     
