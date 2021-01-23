    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class MyClassA
    {
      private int i;
      public MyClassA(int i) { this.i = i; }
    }
    
    public class MyClassB : IEquatable<MyClassB>
    {
      private int i;
      public MyClassB(int i) { this.i = i; }
      public bool Equals(MyClassB other) { return this.i == other.i; }
    }
    
    public class Program
    {
      public static void Main()
      {
        var actual1 = new List<MyClassA>() { new MyClassA(1), new MyClassA(2), new MyClassA(3) };
        var expected1 = new List<MyClassA>() { new MyClassA(1), new MyClassA(2), new MyClassA(3) };
        Console.WriteLine(Enumerable.SequenceEqual(actual1, expected1));
    
        var a1 = new MyClassA(1);
        var a2 = new MyClassA(2);
        var a3 = new MyClassA(3);
        var actual2 = new List<MyClassA>() { a1, a2, a3 };
        var expected2 = new List<MyClassA>() { a1, a2, a3 };
        Console.WriteLine(Enumerable.SequenceEqual(actual2, expected2));
    
        var actual3 = new List<MyClassB>() { new MyClassB(1), new MyClassB(2), new MyClassB(3) };
        var expected3 = new List<MyClassB>() { new MyClassB(1), new MyClassB(2), new MyClassB(3) };
        Console.WriteLine(Enumerable.SequenceEqual(actual3, expected3));
    
        var actual4 = new List<MyClassB>() { new MyClassB(1), new MyClassB(2), new MyClassB(3) };
        var expected4 = new List<MyClassB>() { new MyClassB(3), new MyClassB(2), new MyClassB(1) };
        Console.WriteLine(Enumerable.SequenceEqual(actual4, expected4));
      }
    }
