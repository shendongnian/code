    using System;
    static class Program {
        public static void Main(params string[] args) {
            Type t = typeof(int?);
            Type genericArgument = t.GetGenericArguments()[0];
            Console.WriteLine(genericArgument.FullName);
        }
    }
