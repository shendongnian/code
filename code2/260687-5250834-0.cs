    // traditional transaction script
    public class MailService
    {
        public void UpdateEmail(string userName, string newEmail)()
        {
           if(db.UserExists(userName))
           {
              if(EmailHelper.ValidateEmailFormat(newEmail))
              {
                 db.UpdateEmail(userName, newEmail);
              }
           } 
        }
    }
    
    // transaction script with anemic domain objects
    public class MailService
    {
        public void UpdateEmail(string userName, string newEmail)()
        {
           var userDAO = new UserDAO();
           var emailDAO = new EmailDAO();
    
           var existingUser = userDAO.GetUserByName(userName);       
    
           if(existingUser != null)
           {
              if(EmailHelper.ValidateEmailFormat(newEmail))
              {
                 emailDAO.UpdateEmail(existingUser, newEmail);
              }
           } 
        }
    }
