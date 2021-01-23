    public class ParentFactory
    {
        public static Parent NewParent(String ID)
        {
            Parent newParent = new Parent(ID);
            return newParent;
        }
    }
