      Dictionary<string, Func<int, int, int>> operations = 
        new Dictionary<string, Func<int, int, int>>() {
          { "+", (x, y) => x + y },
          { "-", (x, y) => x - y },
          { "*", (x, y) => x * y },
          { "/", (x, y) => x / y },
      };
      List<string> data = new List<string>() {
        "12", "/", "4", "*", "3"
      };
      // Stack for data
      Stack<int> items = new Stack<int>();
      // Stack for operations
      Stack<Func<int, int, int>> ops = new Stack<Func<int, int, int>>();
      foreach (string item in data)
        if (Regex.IsMatch(item, "^-?[0-9]+$")) // do we have number? 
          if (ops.Any()) // do we have an operation? 
            // if yes, execute it; put the outcome on the stack 
            items.Push(ops.Pop()(items.Pop(), int.Parse(item))); 
          else
            // if no operation, just put item on the stack
            items.Push(int.Parse(item));
        else // operation should be put on its stack
          ops.Push(operations[item]);
      int result = items.Pop();
