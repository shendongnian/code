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
    // More of an OO / DDDish approach
    public class MailService
    {
        public void UpdateEmail(string userName, string newEmail)()
        {
           var userRepository = new Repository<User>();
           var userToUpdate = userRepository.Where(x => x.UserName = userName).FirstOrDefault();
           
           if(userToUpdate != null)
           {
               userToUpdate.Email.Address = newEmail;
               if (user.IsValid())
               {
                   userRepository.Update(userToUpdate);
               } 
           }
        }
    }
