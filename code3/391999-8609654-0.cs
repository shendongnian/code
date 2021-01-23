    public static class PicklistAttributeMetadataExtensions
    {
    public static Dictionary<int?,string> ToDictionary(this PicklistAttributeMetadata picklist)
    {
      return picklist.OptionSet.Options.ToDictionary(x => x.Value, x => option.Label.UserLocalizedLabel.Label.ToString());
    }    
    }
