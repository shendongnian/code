    public class User{
    
    int UserID;
    string Email;
    string Name;
    string Phone;
    string Address
    }
    public static class SessionData{
     static User User{
    get{
    return (User)HttpContext.Current.Session["user"];
    }
    set{
    HttpContext.Current.Session["user"] = value;
    }
     static bool  IsUserConnected{
    get{
    return HttpContext.Current.Session["user"]  != null;
    }
    }
