       public class RequestTemplate : IComparable<RequestTemplate>
       {
          // This is the primary key for the object
          private Guid _guidNumber;
    
          // This is what a collection of these objects should be sorted by
          private string _buttonCaption = "";
    
    
          public Guid GuidNumber
          {
             get { return _guidNumber; }
             set { _guidNumber = value; }  // Setter only provided for deserialization usage
          }
    
          public string ButtonCaption
          {
             get { return _buttonCaption; }
             set { _buttonCaption = value; }
          }
    
    
          /// <summary>
          /// Method needed to allow sorting a collection of these objects.
          /// </summary>
          public int CompareTo(RequestTemplate other)
          {
             return string.Compare(this.ButtonCaption, other.ButtonCaption, 
                                   StringComparison.CurrentCultureIgnoreCase);
          }
       }
    
    
       public class RequestTemplateKeyedCollection : KeyedCollection<Guid, RequestTemplate>
       {
          /// <summary>
          /// Sort the collection by sorting the underlying collection, accessed by casting the Items 
          /// property from IList to List.
          /// </summary>
          public void Sort()
          {
             List<RequestTemplate> castList = base.Items as List<RequestTemplate>;
             if (castList != null)
                castList.Sort();  // Uses default Sort() for collection items (RequestTemplate)
          }
    
    
          /// <summary>
          /// Method needed by KeyedCollection.
          /// </summary>
          protected override Guid GetKeyForItem(RequestTemplate requestTemplate)
          {
             return requestTemplate.GuidNumber;
          }
       }
