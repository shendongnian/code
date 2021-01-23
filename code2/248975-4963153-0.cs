    public class User
    {
       ...
       private string userName;
       public virtual string UserName
       {
           get{return StringFormatter.ToTitleCase(userName.Trim());}
           set{userName = StringFormatter.ToTitleCase(value.Trim());}
       }
       private string email
       public virtual string Email
       {
           get{return email.Trim().ToLower();}
           set{email= value.Trim().ToLower();}
       }
       ...
    }
