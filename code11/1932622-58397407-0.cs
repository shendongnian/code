      using System.Dynamic;
      ...
      dynamic myObject = new ExpandoObject();
      // Compile-time property
      myObject.foo = "abc";
      // Run-time property
      string propertyName = "bar";
      (myObject as IDictionary<string, object>).Add(propertyName, 123);
      Console.Write($"foo = {myObject.foo}; bar = {myObject.bar}");
