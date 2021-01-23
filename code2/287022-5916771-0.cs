    public class MyClass1<T>
    {
      public T Field;			
    }
    
    public class MyClass2<T>
    {
      public T Field = default(T);
    }
You'll see that the compiler does insert the call to default(T) like we asked it to, but of course that call will just return the initial value of the field anyway, so it's not needed.
So, to answer your question: you would take a (very slight) performance hit by explicitly calling default(T), but I don't believe it's going to affect very much in the long run.
