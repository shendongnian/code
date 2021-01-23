    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                NewType1 i1 = new NewType1() { Age = 25, Name = "ABCDFSEFRFD" };
                NewType2 i2 = new NewType2() { AType = AccountType.Checking, Balance = 1000 };
                Console.WriteLine(i1.ToStringLinq());
                Console.WriteLine(i2.ToStringLinq());
                Console.ReadLine();
            }
            public static string ToStringLinq(this object o)
            {
                return o.GetType().FullName 
                + Environment.NewLine 
                + string.Join(Environment.NewLine, (from p in o.GetType().GetProperties()
                                                    select string.Format("{0}{1}{2}", p.Name, ':', p.GetValue(o, null))));
            }
        }
        public class NewType1
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class NewType2
        {
            public int Balance { get; set; }
            public AccountType AType { get; set; }
        }
        public enum AccountType
        {
            Savings,
            Checking
        }
    }
