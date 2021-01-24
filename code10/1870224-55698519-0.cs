public class LookupResponseModel
{
  public LookupTableData[][] lookupTableData { get; set; }
  public class LookupTableData
  {
      public string Key { get; set; }
      public object Value { get; set; }
  }
  public LookupTableData[] FindById( int id )
  {
    if (this.lookupTableData == null) throw new InvalidOperationException();
    foreach ( LookupTableData[] entry in lookupTableData )
    {
      if (entry != null)
      {
        foreach( LookupTableData item in entry )
        {
          if ( item.Key != null && item.Key.Equals("id", StringComparison.Ordinal) )
          {
            return entry;
          }
        }
      }
    }
    return null;
  }
}
