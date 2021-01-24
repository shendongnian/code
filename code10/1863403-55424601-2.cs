C#
class User {
    ...
   public User() {}
   private User(string s) {
       // Can only be called inside User class
       Console.WriteLine(s);
   }
    public static User Create() {
        return new User("Creating user from method...");
    }
}
