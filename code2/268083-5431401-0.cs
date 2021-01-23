    string username = "myUsr";
    string password = "myPwd";
    DateTime createDate = DateTime.UtcNow;
    // Salt it
    string saltedPwd = String.Concat(password, SomeOtherClass.StaticKey, createDate.Ticks.ToString());
    public class SomeOtherClass
    {
        public static string StaticKey = "#$%#$%superuniqueblahal$#%@#$43580"; // should probably be const/readonly, but whatever
    }
