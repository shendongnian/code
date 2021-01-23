    public abstract class Foo
    {
      public abstract void Bar();
    }
    
    public static class FooExtensions
    {
      // most useless extension method evar
      public static void CallBar(this Foo me)
      {
        me.Bar();
      }
    }
