      // Let's extract the model: all possible infix binary operations
      Dictionary<string, Func<double, double, double>> operations = 
        new Dictionary<string, Func<double, double, double>>() {
          { "+", (x, y) => x + y },
          { "-", (x, y) => x - y },
          { "*", (x, y) => x * y },
          { "/", (x, y) => x / y },
      };
      List<string> data = new List<string>() {
        "12", "/", "4", "*", "3"
      };
      // Stack for data
      Stack<double> items = new Stack<double>();
      // Stack for operations
      Stack<Func<double, double, double>> ops = new Stack<Func<double, double, double>>();
      foreach (string item in data)
        if (double.TryParse(item, out double v)) // do we have number? 
          if (ops.Any()) // do we have an operation? 
            // if yes, execute it; put the outcome on the stack 
            items.Push(ops.Pop()(items.Pop(), v)); 
          else
            // if no operation, just put item on the stack
            items.Push(v);
        else // operation should be put on its stack
          ops.Push(operations[item]);
      double result = items.Pop();
