public class MyClass: IEnumerable<KeyValuePair<string , int>>
{
  private readonly List<KeyValuePair<string , int>> AllContacts
    = new List<KeyValuePair<string , int>>();
  public int ContactsCount
  {
    get { return AllContacts.Count; }
  }
  public KeyValuePair<string , int> this[int index]
  {
    get { return AllContacts[index]; }
    set { AllContacts[index] = value; }
  }
  public int Add(KeyValuePair<string , int> item)
  {
    ...
  }
  ...
}
