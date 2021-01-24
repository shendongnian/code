    public class User{
         public string e;
         public string p;
         public User(string email, string pass){
         this.e= email;
         this.p= pass; 
         }
         public string Pass{
        
                get { return this.p; }
        
                set { this.p= value; }
        
         }
         public string Email{
        
                get { return this.e; }
        
                set { this.e= value; }
        
         }
     }
