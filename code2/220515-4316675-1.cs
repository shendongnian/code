    interface IDBModel {
      DataTable LoadUser(Int32 userId);
    }
    class MyDbModel : IDBModel {
      DataTable LoadUser(Int32 userId) {
        // make the appropriate DB calls here, return a data table
      }
    }
    class User {
      public User(IDBModel dbModel, Int32 userId) {
        DataTable data = dbModel.LoadUser(userId);
        // assign properties.. load any additional data as necessary
      }
    // You can do cool things like call User.Save() 
    // and have the object validate and save itself to the passed in 
    // datamodel.  Makes for simpler coding.
    }
    class MyServiceLayer {
      public User GetUser(Int32 userId) {
        IDBModel model = new MyDbModel();
    
        return new User(model, userId);
      }
    }
