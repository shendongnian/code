    using System;
    
    namespace TestEnvironmentVariable
    {
        class Program
        {
            static void Main(string[] args)
            {
                string testEnvironment = Environment.GetEnvironmentVariable("test_env");
                Console.WriteLine($"Test environment: {testEnvironment}");
            }
        }
    }
