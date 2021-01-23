    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            Test(employees);
        }
        static void Test(IEnumerable<Person> persons)
        {
            // Do something
        }
    }
    public class Person { }
    public class Employee : Person { }
