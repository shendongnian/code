    public class CreatedBy
    {
        public string Id { get; set; }
        public string ItemDisplayText { get; set; }
        public string ItemType { get; set; }
    }
    
    public class ModifiedBy
    {
        public string Id { get; set; }
        public string ItemDisplayText { get; set; }
        public string ItemType { get; set; }
    }
    
    public class Owner
    {
        public string Id { get; set; }
        public string ItemDisplayText { get; set; }
        public string ItemType { get; set; }
    }
    
    public class EntityDetails
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public Owner Owner { get; set; }
    }
    
    public class NameComponents
    {
        public string FullName { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
    }
    
    public class MaritalStatus
    {
        public string Id { get; set; }
        public string DisplayTitle { get; set; }
        public string ItemDisplayText { get; set; }
        public string ItemType { get; set; }
    }
    
    public class DefaultPosition
    {
        public string PositionId { get; set; }
        public EntityDetails EntityDetails { get; set; }
        public NameComponents NameComponents { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
    
    public class RootObject
    {
        public string Id { get; set; }
        public DefaultPosition DefaultPosition { get; set; }
    }
...
      var root = JsonConvert.DeserializeObject<RootObject>(json);
    
      var fullname = root.DefaultPosition.NameComponents.FullName;
