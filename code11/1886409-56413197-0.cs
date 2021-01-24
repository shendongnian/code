    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                S1 newItem = new S1()
                {
                    Age = 11,
                    Name = "John"
                };
    
                D1 oldItem = new D1()
                {
                    Age = 10
                };
    
                //there is an item in a database which is of D1 type. This convertor receives an object S1 in order to update the D1 item.
                // the rule is that Sx updatates Dx (where x is 1,2,3,4,5...)
                Convertor<S1, D1> convertor = new Convertor<S1, D1>(newItem, oldItem);
    
                S2 newItem2 = new S2()
                {
                    City = "London",
                    Name = "Lynda"
                };
    
                D2 oldItem2 = new D2()
                {
                    City = "Paris"
                };
    
                Convertor<S2, D2> convertor2 = new Convertor<S2, D2>(newItem2, oldItem2);
                Console.ReadKey();
            }
        }
    
        public interface ICopyable<T>
        {
            void CopyFrom(T other);
        }
    
        public abstract class SourceDomain
        {
            public string Name { get; set; }
        }
    
    
        public class S1 : SourceDomain
        {
            public int Age { get; set; }
        }
    
        public class S2 : SourceDomain
        {
            public string City { get; set; }
        }
    
        public class DestinationDomain { }
        public class D1 : DestinationDomain, ICopyable<S1>
        {
            public int Age { get; set; }
    
            public void CopyFrom(S1 other)
            {
                Console.WriteLine("oldItem.Age " + Age + " new Age; = " + other.Age);
                Age = other.Age;
                Console.WriteLine("oldItem.Age " + Age + " new Age; = " + other.Age);
            }
        }
        public class D2 : DestinationDomain, ICopyable<S2>
        {
            public string City { get; set; }
    
            public void CopyFrom(S2 other)
            {
                City = other.City;
                Console.WriteLine(" oldItem.City = City;");
            }
        }
    
        public class Convertor<X, Y> where X : SourceDomain  where Y : DestinationDomain, ICopyable<X>
        {
            protected X item;
            protected Y oldItem;
    
            public Convertor(X newObject, Y oldObject)
            {
                item = newObject;
                oldItem = oldObject;
    
                //here I want to call, depending of X type, the proper method, not the base one.
                oldItem.CopyFrom(item);
                Console.WriteLine(item);
            }
        }
    }
