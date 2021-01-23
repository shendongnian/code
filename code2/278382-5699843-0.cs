    [Flags]
    public enum AccountType
    {
        Guest,
        User,
        Teacher = 2,
        Admin = 4
    }
    
    public class Account
    {
        public bool IsTeacher
        {
           get { return (user.AccountType & AccountType.Teacher) != 0; }
        }
        public int AccounType {get;set;}
    }
    var teacherAndAdmin = AccountType.Teacher + AccountType.Admin;
