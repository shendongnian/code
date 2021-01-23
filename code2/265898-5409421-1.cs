    public abstract class MyBase {
        protected static DataContext db = null;
        protected static DataContext GetDataContext() {
            return new DataContext("My Connection String");
        }
        // rest of class
    }
