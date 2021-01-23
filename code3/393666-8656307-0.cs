     using MonoTouch.Foundation;
     using MonoTouch.ObjCRuntime;
     namespace AlexD {
         [BaseType (typeof (NSObject))]
         interface TestClass {
             [Export ("SomeString")] string SomeString { get; set; }
             [Export ("getString")]  string GetString ();
             [Export ("getInt")]     int    GetInt ();
         }
     }
