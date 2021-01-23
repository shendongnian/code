    class DataManager
    {
       private MyContext db;
       public DataManager() {
           db = new MyContext();
       }
       public User[] getList()
       {
           return db.Users.Where(item => item.Active == false);
       }
       public User[] addUser(string name)
       {
           db.Users.InsertOnSubmit(new User() { id = Guid.NewId(),  name = name, active = false ...});
           return getList();
       }
    }
