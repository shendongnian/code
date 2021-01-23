    public class AutoDictionary<K,V> : Dictionary<K,V>
    {
       public Func<V,K> KeyGenerator { get; set; }
       public void Add(V value)
       {
          Add(KeyGenerator(V),V);
       }
    }
    
    ...
    
    var myContainer = new AutoDictionary<CustomId, Element>();
    myContainer.KeyGenerator = e=> e.id;
    myContainer.Add(myElement);
    var elementFromDictionary = myContainer[myElement.id]; //will be the same instance as myElement
