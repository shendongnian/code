    public class Item
    {
      public IList<Tag> Tags {get;set;}
      public void AddTag(String tagName)
      {
        var tagAlreadyExists = Tags.Any(a=>String.Compare(a.Name,tagName,StringComparison.OrdinalIgnoreCase)==0;
        if (tagAlreadyExists )
          return; // Or throw exception
        Tags.Add(new Tag(tagName));
      }
    }
