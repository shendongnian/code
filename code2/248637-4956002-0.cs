Well you could write yourself an AsyncObservableCollection, if you know how to write it threadsafe. Then you can encapsulate the Dispatcher calls in it. 
The problem is you would not use the standard ObservableCollection delivered within the .Net - Framework. It would increase the risk of errors in your application.
Another option would be to implement a WrapperClass, which contains and exposes an ObservableCollection for binding and has methods to modify the collection.
public class WrapperClass&lt;T&gt;
{
   public ObservableCollection&lt;T&gt; Collection {get; set;}
   
   public void Add(T item) 
   { 
      //do your dispatcher magic here 
   }
   ...
}
