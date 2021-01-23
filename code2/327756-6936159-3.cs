    public class Parent
    {
        [key]
        public string parentID {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
        public string Firstname {get;set;}
    
        public Email Email{get;set;}
    }
    
    public class Email
    {
        public string EmailID {get;set;}
        public string Email {get;set;}
        public string ParentID {get;set;}
    }
     public partial class MyDbContext:DbContext
    {
          public DbSet<Parents> Parents{ get; set; }
          public DbSet<Email> Emails{ get; set; }
    }
    
    var db= new MyDbContext();
    var parent = db.Parent.include("Email").tolist();
