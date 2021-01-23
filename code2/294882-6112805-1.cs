    public class Bar : IDisposable
    {
      private bool _disposed;
      public void Dispose()
      {
         Dispose( true );
         GC.SuppressFinalize( this );
      }
      protected virtual void Dispose( bool disposing )
      {
         if ( disposing )
         {
            if ( !_disposed )
            {
               _disposed = true;
            }
         }
      }
    }
    public abstract class FooBase : IDisposable
    {
      public Bar Bar
      {
         get;
         set;
      }
      internal FooBase( Bar bar )
      {
         Bar = bar;
      }
      private bool _disposed;
      public void Dispose()
      {
         Dispose( true );
         GC.SuppressFinalize( this );
      }
      protected virtual void Dispose( bool disposing )
      {
         if ( disposing )
         {
            if ( !_disposed )
            {
               if ( Bar != null )
               {
                  Bar.Dispose();
               }
               _disposed = true;
            }
         }
      }
    }
    public class FooA : FooBase
    {
      public FooA( Bar bar )
         : base( bar )
      {
      }
    }
    public static class FooProvider
    {
      public static FooA GetFooA()
      {
         Bar bar;
         using ( bar = new Bar() )
         {
            return new FooA( bar );
         }
      }
    }
    [TestClass]
    public class UnitTest1
    {
      [TestMethod]
      public void StaticAnalysisTest()
      {
         Assert.IsNotNull( FooProvider.GetFooA().Bar );
      }
    }
