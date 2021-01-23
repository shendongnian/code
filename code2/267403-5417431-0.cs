    #region some stubs (replaced with your types)
    
    public class Shape { }
    public class MockSquare : Shape { }
    public class MockCircle : Shape { }
    public class MockShapeFactory
    {
      //I've added a constraint so I can new the instance
      public static T CreateMockShape<T>()
        where T : Shape, new()
      {
        Console.WriteLine("Creating instance of {0}", typeof(T).FullName);
        return new T();
      }
    }
    #endregion
    //you can cache the reflected generic method
    System.Reflection.MethodInfo CreateMethodBase =
      typeof(MockShapeFactory).GetMethod(
        "CreateMockShape", 
        System.Reflection.BindingFlags.Public 
        | System.Reflection.BindingFlags.Static
      );
    [TestMethod]
    public void TestDynamicGenericBind()
    {
      //the DynamicBindAndInvoke method becomes your replacement for the 
      //MockShapeFactory.CreateMockShape<typeof(mockType)>() call
      //And you would pass the 'mockType' parameter that you get from
      //getAppropriateMockType<TBase>();
      Assert.IsInstanceOfType
        (DynamicBindAndInvoke(typeof(MockCircle)), typeof(MockCircle));
      Assert.IsInstanceOfType
        (DynamicBindAndInvoke(typeof(MockSquare)), typeof(MockSquare));
    }
    //can change the base type here according to your generic
    //but you will need to do a cast e.g. <
    public Shape DynamicBindAndInvoke(Type runtimeType)
    {
      //make a version of the generic, strongly typed for runtimeType
      var toInvoke = CreateMethodBase.MakeGenericMethod(runtimeType);
      //should actually throw an exception here.
      return (Shape)toInvoke.Invoke(null, null);
    }
