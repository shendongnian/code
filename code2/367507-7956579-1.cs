    public class UriDetails : DynamicObject
    {
        //TODO put error handling in here to ensure that they're not empty?
        public string ResourceName { get; set; }
        public int ResourceId { get; set; }
    
        public UriDetails(int resourceId, string resourceName)
        {
            ResourceId = resourceId;
            ResourceName = resourceName;
        }
    //other code that you need to override
    }
