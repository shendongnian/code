    public class ChildFactory
    {
        public static Child  NewChild(String ID)
        {
            Child newChild = new Child(ID);
            return newChild;
        }
        public static Child  NewChild(String ID, String Name)
        {
            Child newChild = new Child(ID, Name);
            return newChild;
        }
    }
