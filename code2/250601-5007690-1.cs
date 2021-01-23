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
    class Program
    {
        static void Main(string[] args)
        {
            Person brother = new Person();
            ActionMan am = new ActionMan();
            am.guns = "Laser Beam";
            brother.actionMan = am;
            Person sister = new Person();
            Doll d = new Doll();
            d.name = "Jill";
            sister.doll = d;
            Serialize(brother, "brother.xml");
            Serialize(sister, "sister.xml");
            Person b = Deserialize("brother.xml");
            Person s = Deserialize("sister.xml");
            Console.WriteLine(((ActionMan)b.toy).guns);
            Console.WriteLine(((Doll)s.toy).name);
            Console.Read();
        }
        public static Person Deserialize(String filename)
        {
            var serializer = new XmlSerializer(typeof(Person));
            return (Person)serializer.Deserialize(new FileStream(filename, FileMode.Open));
          
        }
        public static void Serialize(Person p, String filename){
            Stream stream = File.Open(filename, FileMode.Create);
            XmlSerializer s = new XmlSerializer(typeof(Person));
            s.Serialize(stream, p);
            stream.Close();
        }
