    $ cat Test.cs
    using System;
    namespace Test
    {
       public class TestClass
       {
          public static void Main(string[] args)
          {
             DateTime example = DateTime.Now;
             Console.WriteLine(example);
          }
       }
    }
    $ gmcs *.cs
    $ mono Test.exe
    2/18/2011 11:03:13 PM
