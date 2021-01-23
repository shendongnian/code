    public class UserType
    {
        int UserID { get; set; }
        string UserName { get; set; }
        string UserPassword { get; set; }
    )
    
    [SqlProcedure]
    public static void SomeFunction (UserType type)
    {
         //
    }
