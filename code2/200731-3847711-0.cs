    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.ComponentModel;
    namespace TypeConversionTest
    {
      class Program
      {
        static void Main(string[] args)
        {
          Foo foo = "fooTest";
          Console.WriteLine("Foo value: {0}", foo.Name);
          Console.ReadLine();
        }
      }
      public class Foo
      {
        public string Name { get; set; }
        public override bool Equals(object other)
        {
          if (Name == null)
            return (other == null);
          else
            return other != null && Name == (string)other;
        }
        public override int GetHashCode()
        {
          return Name != null ? Name.GetHashCode() : 0;
        }
        public override string ToString()
        {
          return Name;
        }
        public static implicit operator Foo(string value)
        {
          return new Foo { Name = value };
        }
      }
    }
