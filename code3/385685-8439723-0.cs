    using System.Web.Security;
    
    namespace YourNameSpace
    {
        
        public class CustomSqlMembershipProvider : SqlMembershipProvider
        {
            
            public bool CreateUser(//list of parameters)
            {
                bool UserCreated = false;
                MembershipCreateStatus status;
    
    			//provide the required parameters 
                base.CreateUser(//list of parameters);
    
                if (status == 0)//user was successfully created
                { 
                    //perform your custom code
    				//if success 
    				UserCreated = true;
                }
    			
    			return UserCreated
            }
        }
    }
