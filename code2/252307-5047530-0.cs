       class Program
        {
            [DataContract(Name = "A", Namespace = "http://www.ademo.com")]
            public class A { }
             [DataContract(Name = "A", Namespace = "http://www.ademo.com")]
            public class B : A  {
                 [DataMember()]
                 public string FirstName;
            }  
        static void Main(string[] args)
        {
            B itemB = new B();
            itemB.FirstName = "Fred";
            A itemA = (A)itemB; 
            Console.WriteLine(itemA.GetType().FullName);
            A wipedA = WipeAllTracesOfB(itemB);
            Console.WriteLine(wipedA.GetType().FullName);
        }
        public static A WipeAllTracesOfB(A a)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(A));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, a);
                ms.Position = 0;
                A wiped = (A)serializer.ReadObject(ms);
                return wiped;
            }
        }
    }
