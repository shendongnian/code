    public class MyClass
    {
      public MyClass()
      {
        myCollection = new ObservableCollection<Message>();
        myReadOnlyCollection = new ReadOnlyObservableCollection<Message>(myCollection);
      }
 
      public ReadOnlyObservableCollection<Message> Messages 
      {
        get { return myReadOnlycollection; }
      }
 
      private readonly ObservableCollection<Message> myCollection;
      private readonly ReadOnlyObservableCollection<Message> myReadOnlyCollection;
    }
