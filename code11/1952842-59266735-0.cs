public class Logic
{
  private readonly List<MyObject> allMyObjects; // note that they still are not instantiated yet
  public Logic()
  {
    cont int amount = 200;
    allMyObjects = new List<MyObject>(amount); // reserve space, but all are still null
    InstantiateAllObjects(allMyObjects, amount);
  }
  private void InstantiateAllObjects(List<MyObject> list, int amount)
  {
    for (int i=0; i<amount; i++)
    {         
      MyObject obj = new MyObject();
      obj.Name = "Object" + (i+1).ToString("000"); 
      obj.PropertyChanged += (s, e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
      allMyObjects.Add(obj); // place the newly created object in the list
    }
  }
}
Your original test `if(list[i]==Object001)` fires every time, because both `list[i]` (for every i) and `Object001` are null.
