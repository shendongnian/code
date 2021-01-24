    public interface ICopyable<T>
    {
        void CopyFrom(T other);
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var newItem = new SourceDomain<Person>
            {
                Item = new Person { Age = 11 },
                Name = "John"
            };
            var oldItem = new DestinationDomain<Person>
            {
                Item = new Person { Age = 10 }
            };
            //there is an item in a database which is of D1 type. This convertor receives an object S1 in order to update the D1 item.
            // the rule is that Sx updatates Dx (where x is 1,2,3,4,5...)
            Convertor<Person> convertor = new Convertor<Person>(newItem, oldItem);
            var newItem2 = new SourceDomain<Location>()
            {
                Item = new Location { City = "London" },
                Name = "Lynda"
            };
            var oldItem2 = new DestinationDomain<Location>()
            {
                Item = new Location {  City = "Paris" }
            };
            Convertor<Location> convertor2 = new Convertor<Location>(newItem2, oldItem2);
            Console.ReadKey();
        }
    }
    public class SourceDomain<T>
    {
        public string Name { get; set; }
        public T Item { get; set;  }
    }
    public class DestinationDomain<T> where T : ICopyable<T>, new()
    {
        public string Name { get; set; }
        public T Item { get; set; }
        public void CopyItemFrom(T other)
        {
            if (Item == null)
            {
                Item = new T();
            }
            Item.CopyFrom(other);
        }
    }
    //  A person is a thing which can turn itself into a copy of another Person. 
    //  You could define a class Wombat : ICopyable<Locomotive>, if you wanted to be 
    //  able to convert Locomotives to Wombats. You'd just add another CopyFrom()
    //  overload, public void CopyFrom(Locomotive other). 
    public class Person : ICopyable<Person>
    {
        public int Age { get; set; }
        public void CopyFrom(Person other)
        {
            Age = other.Age;
        }
    }
    public class Location : ICopyable<Location>
    {
        public String City { get; set; }
        public void CopyFrom(Location other)
        {
            City = other.City;
        }
    }
    public class Convertor<X> where X : ICopyable<X>, new()
    {
        protected SourceDomain<X> item;
        protected DestinationDomain<X> oldItem;
        public Convertor(SourceDomain<X> newObject, DestinationDomain<X> oldObject)
        {
            item = newObject;
            oldItem = oldObject;
            //here I want to call, depending of item type, the proper method, not the base one.
            //newObject.Data = oldItem.Data;
            oldItem.CopyItemFrom(item.Item);
        }
    }
