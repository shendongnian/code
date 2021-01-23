     var stack = new Stack<Tuple<object, object>>();
     // prime the stack
     foreach (var prop in n1.GetType().GetProperties())
     {
         stack.Push(nTuple.Create(prop.GetValue(n1), prop.GetValue(n2));
     }
     while (stack.Count > 0)
     {
         var current = stack.Pop();
         
         // if current is promitive: compare
         // if current is enumerable: push all elements as Tuples on the stack
         // else: push all properties as tuples on the stack
     }
