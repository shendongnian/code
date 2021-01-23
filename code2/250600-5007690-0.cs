     public class Person 
    {
        public Toy toy
        {
            get
            {
                return (doll == null) ? (Toy)actionMan : (Toy)doll;
            }
        }
        public Doll doll;
        public ActionMan actionMan;
    }
    public class Toy 
    {
    }
    public class Doll : Toy
    {
        public String name;
    }
    public class ActionMan : Toy
    {
        public String guns;
    }
