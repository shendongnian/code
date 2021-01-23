    using System;
    using System.Collections.Generic;
    class Test
    {
      static void Main()
      {
        var stack = new Stack<string>();
        stack.Push("pushed first, pop last");
        stack.Push("in the middle");
        stack.Push("pushed last, pop first");
        var quickCopy = new Queue<string>(stack);
        Console.WriteLine("Stack:");
        while (stack.Count > 0)
          Console.WriteLine("  " + stack.Pop());
        Console.WriteLine();
        Console.WriteLine("Queue:");
        while (quickCopy.Count > 0)
          Console.WriteLine("  " + quickCopy.Dequeue());
      }
    }
