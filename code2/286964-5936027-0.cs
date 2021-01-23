    [DataContract]
    public class UserForService1 : User
    {
         private User mUser;
         public UserForService1(User u)
         {
             mUser = u;
         }
         
         //expose only properties you'd like the user of this data contract to see
         [DataMember]
         public string SomeProperty
         {
             get
             {
                //always call into the 'wrapped' object
                return mUser.SomeProperty;
             }
             set
             {
                mUser.SomeProperty = value;
             }
         }
         // etc...
    }
