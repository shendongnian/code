    public Role GetRole(string rolestring)
    {
         Role result; 
         foreach(string rolename in Enum.GetNames(typeof(Role)))
         {
           if(rolename == rolestring)
           {
               try 
               {
                 result = (Role) Enum.Parse(typeof(Role), rolename); 
               }
               catch(ArgumentException e)
               {
                     //Most unlikely we ever enter this catch s we know for sure we have role
                     //Process if role not found
                     throw;
               }
           }
         }
         return result;
    }
