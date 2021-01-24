    using System;
    using NUnit.Framework;
    namespace UnitTestProject1
    {
        public class Base<T>
        {
            private static T[] Values;
            [TestCaseSource(nameof(Values))]
            public void MyTest(T value)
            {
                Console.WriteLine($"Base: {value}");
                // Some test here with the values;
            }
        }
        [TestFixture]
        public class Derived : Base<string>
        {
            private static string[] Values= new[] { "One", "Two" };
            [TestCaseSource(nameof(Values))]
            public void DerivedSpecificTest(string value)
            {
                // Some test here with the values;
                Console.WriteLine($"Derived: {value}");
            }
        }
    }
