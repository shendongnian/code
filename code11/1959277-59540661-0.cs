    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 500; i++)
            {
                int j = i;
                Task.Run(() => new Employee().ProcessEmployee(j));
            }
            Console.Read();
        }
    }
    public class Employee
    {
        public void ProcessEmployee(int employeeId)
        {
            Console.WriteLine($"The number is: {employeeId} and thread is {Thread.CurrentThread.ManagedThreadId}");
        }
    }
