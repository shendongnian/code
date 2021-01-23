    public class Base
    {
      public string BaseString { get; set; }
    }
    public class Derived : Base
    {
      public string DerivedString { get; set; }
    }
    public static class SO4870831Extensions
    {
      private static Dictionary<Type, Action<Base>> _helpers = 
        new Dictionary<Type,Action<Base>>();
      public static void Extension<TBase>(this TBase instance) 
        where TBase :Base
      {
        //see if we have a helper for the absolute type of the instance
        var derivedhelper = ResolveHelper<TBase>(instance);
        if (derivedhelper != null)
          derivedhelper(instance);
        else
          ExtensionHelper(instance);
      }
      public static void ExtensionHelper(this Base instance)
      {
        Console.WriteLine("Base string: {0}", 
          instance.BaseString ?? "[null]");
      }
      /// <summary>
      /// By Default this method is resolved dynamically, but is also 
      /// available explicitly.
      /// </summary>
      /// <param name="instance"></param>
      public static void ExtensionHelper(this Derived instance)
      {
        Console.WriteLine("Derived string: {0}", 
          instance.DerivedString ?? "[null]");
        //call the 'base' version - need the cast to avoid Stack Overflow(!)
        ((Base)instance).ExtensionHelper();
      }
      private static Action<Base> ResolveHelper<TBase>(TBase instance) 
        where TBase : Base
      {
        Action<Base> toReturn = null;
        Type instanceType = instance.GetType();
        if (_helpers.TryGetValue(instance.GetType(), out toReturn))
          return toReturn;  //could be null - that's fine
        //see if we can find a method in this class for that type
        //this could become more complicated, for example, reflecting
        //the type itself, or using attributes for richer metadata
        MethodInfo helperInfo = typeof(SO4870831Extensions).GetMethod(
          "BaseExtensionHelper", 
          BindingFlags.Public | BindingFlags.Static, 
          null, 
          new Type[] { instanceType }, 
          null);
        if (helperInfo != null)
        {
          ParameterExpression p1 = Expression.Parameter(typeof(Base), "p1");
          toReturn =
            Expression.Lambda<Action<Base>>(
            /* body */
              Expression.Call(
                helperInfo,
                Expression.Convert(p1, instanceType)),
            /* param */
              p1).Compile();
          _helpers.Add(instanceType, toReturn);
        }
        else
          //cache the null lookup so we don't expend energy doing it again
          _helpers.Add(instanceType, null);
        return toReturn;
      }
    }
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
      [TestMethod]
      public void TestMethod1()
      {
        var a = new Base() { BaseString = "Base Only" };
        var b = new Derived() { DerivedString = "Derived", BaseString = "Base" };
        a.Extension();
        //Console output reads:
        //"Base String: Base Only"
        b.Extension();
        //Console output reads:
        //"Derived String: Derived"
        //"Base String: Base"
      }
