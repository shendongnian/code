    public static class ExtraObjectStatics
    {
      public static void NewStaticMethod()
      {
      }
    }
    public class Test
    {
      public void foo()
      {
        //You can't do this - the static method doesn't reside in the type 'object'
        object.NewStaticMethod();
        //You can, of course, do this
        ExtraObjectStatics.NewStaticMethod();
      }
    }
