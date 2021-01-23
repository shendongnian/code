    public class LibraryClassWrapper
    {
       private LibraryClass _libraryClass = new LibraryClass();
       public void MyFoo()
       {
          // do something... then call a method in the LibraryClass (if required)
          _libraryClass.Foo();
       }
    }
