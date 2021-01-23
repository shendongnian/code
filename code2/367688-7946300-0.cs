    class Program
    {
        static void Main(string[] args)
        {
            //original parents
            Father father = new Father("George");
            Mother mother = new Mother("Mary");
            //mothers parents aka grandparents
            mother.Mother = new Mother("Ana");
            mother.Father = new Father("Jack");
        }
    }
    abstract class Ancestor
    {
        public String Name { get; set; }
    }
    public class Father : Ancestor {
        public Mother Mother { get; set; }
        public Father Father { get; set; }
        public Father(String name)
        {
            base.Name = name;
        }
    }
    public class Mother : Ancestor {
        public Mother Mother { get; set; }
        public Father Father { get; set; }
        public Mother(String name)
        {
            base.Name = name;
        }
    }
