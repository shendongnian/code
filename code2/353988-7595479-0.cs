     public class StringValue : IHasValue<string>
     {
         public string Value { get; set; }
     }
     public interface LoginClickable : IClickable
     {
         public void SubscribeOnClick(EventHandler click)
         {
              // do something to login
         }
     } 
     public interface CancelClickable : IClickable
     {
         public void SubscribeOnClick(EventHandler click)
         {
              // do something to cancel
         }
     } 
...
        public IHasValue<string> Username
        {
            get { return new StringValue { Value = "Username" }; }
        }
        public IHasValue<string> Password
        {
             get { return new StringValue { Value = "Password" }; }
        }
        public IClickable Login
        {
            get { return new LoginClickable(); }
        }
        public IClickable Cancel
        {
            get { return new CancelClickable(); }
        }
