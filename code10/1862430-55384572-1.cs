    internal class Program
    {
        static int studentNumber;
        static string studentName;
        static int age;
        static int phoneNumber;
        public static void enterData()
        {
            Console.WriteLine("Enter Student Number:");
            studentNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            studentName = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter phone number:");
            phoneNumber = int.Parse(Console.ReadLine());
        }
        public static void displayData()
        {
            Console.WriteLine("Student Number:{0}", studentNumber);
            Console.WriteLine("Student Name:{0}", studentName);
            Console.WriteLine("Student Age:{0}", age);
            Console.WriteLine("Student phone number:{0}", phoneNumber);
            Console.ReadKey();
        }
        public static void Main(String[] args)
        {
            enterData();
            displayData();
        }
    }
