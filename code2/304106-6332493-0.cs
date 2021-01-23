    public class Login
    {
        public string[] array = new string[3];
        public string UserName;
        public string Password;
        public string Message;
    
    
    public Login()
    {
       UserName = array[0] = "admin";
       Password = array[1] = "admin"; 
       Message = array[2] = "Welcome";
    
    }
    
    public void Helpdesk()
    {
        UserName = "help";
        Password = "help123";
        Message = "Welcome Helpdesk!";
        Console.WriteLine(UserName); //still prints admin
        Console.WriteLine(Password); // still prints admin
        Console.WriteLine(Message); // still prints Welcome
    }
    public void IT()
    {
        UserName = "it";
        Password = "Pa$$w0rd";
        Message = "Welcome IT!";
    
    }
    }
