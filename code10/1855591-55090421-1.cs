     public class Transaction 
     {
         public int ID;
         public bool ValidateSecurityInfo()
         {
               //Securityinfo can only be used within the Transaction class
               var info = new SecurityInfo();
          }
          private class SecurityInfo 
          {
          }
     }
