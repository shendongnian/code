    public class User
    {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
        
       public void UpdateLastName()
       {
          ConfirmToUpdate();
        
          //do db actions.  
       }
        
       private void ConfirmToUpdate()
       {
         if (Id <= 0 || string.IsNullOrEmpty(LastName))
             throw new Exception("Properties are not correct to update");
       }
    }
