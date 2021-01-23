foreach (var item in collection)
{
  //the following statements would generate an error.
  collection.Add(new Item());
  collection.Remove(item);
}
