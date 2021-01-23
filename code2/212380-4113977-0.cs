    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    namespace MoqVerifySet
    {
    public interface MyInterface
    {
        string MyValue { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mockMyInterface = new Mock<MyInterface>();
            mockMyInterface.SetupProperty(f => f.MyValue);
            MyInterface myI = mockMyInterface.Object;
            myI.MyValue = @"hello 
                            world.
                            Please ignore
                            the whitespace";
            try
            {
                var comparer = new CompareWithoutWhitespace(StringComparison.CurrentCultureIgnoreCase);
                Assert.IsTrue(comparer.Equals(myI.MyValue, "hello world. Please ignore the whitespace"));
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex.Message);
            }
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
    internal class CompareWithoutWhitespace : StringComparer
    {
        private readonly StringComparison _stringComparison;
        public CompareWithoutWhitespace(StringComparison stringComparison)
        {
            _stringComparison = stringComparison;
        }
        public override int Compare(string x, string y)
        {
            return String.Compare(RemoveWhitespace(x), RemoveWhitespace(y), _stringComparison);
        }
        public override bool Equals(string x, string y)
        {
            return String.Equals(RemoveWhitespace(x), RemoveWhitespace(y), _stringComparison);
        }
        public override int GetHashCode(string obj)
        {
            return RemoveWhitespace(obj).GetHashCode();
        }
        private static string RemoveWhitespace(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            input = input.Replace(Environment.NewLine, "");
            return input.Replace(" ", "");
        }
    }
    }
