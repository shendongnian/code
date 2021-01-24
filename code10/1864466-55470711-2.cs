      var t = Type.GetType("ChineeseRevolution.Actions.AutoPath");
      var x = Expression.Call(
         typeof(Program).GetMethod(
         nameof(DoSomethingWithList),
         System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.NonPublic)
         .MakeGenericMethod(t));
      var y = Expression.Lambda(x);
      y.Compile().DynamicInvoke();
