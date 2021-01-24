    // Foo.cs
    public partial class Foo
    {
      
       /// <summary>
       /// Main constructor
       /// </summary>
       public Foo(){}
    }
    // Foo.Debug.cs
    public partial class Foo
    {
      #if DEBUG
      /// <summary>
      /// Debug only constructor
      /// </summary>
      internal Foo(bool dummy){}
    
      #endif
    }
