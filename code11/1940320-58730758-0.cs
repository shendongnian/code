    public class SmtpSettings{
      public string Server {get;set;}
      public int Port {get;set;}
      public string FromAddress {get;set}
    }
    var smtpSettings = Configuration.GetSection("Smtp");
