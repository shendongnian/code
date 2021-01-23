    class TestProgram
    {
        static void Main(string[] args)
        {
            int age = 32;
            WriteWithConcat(age);
            WriteWithFormat(age);
        }
   
        static void WriteWithConcat(int age)
        {
            Console.WriteLine("The age of the person is : " + age.ToString());
        }
        static void WriteWithFormat(int age)
        {
            Console.WriteLine("The age of the person is : {0}", age);
        }
    }
