public IEnumerable&lt;MyBaseClass&gt; GetFilteredObjects(Type type, List&lt;List&lt;MyBaseClass&gt;&gt lists)
{
  foreach(var list in lists)
  {
    foreach(var item in list)
    {
      if(item.GetType() == type)
        yield return item;
    }
  }
}
