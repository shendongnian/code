    class Program
    {
        static void Main(string[] args)
        {
            var employees = new ObservableCollection<Employee>();
            var persons = employees.OfType<Person>();
            Test(new ObservableCollection<Person>(persons));
        }
        static void Test(ObservableCollection<Person> persons)
        {
            // Do something
        }
    }
    public class Person { }
    public class Employee : Person { }
