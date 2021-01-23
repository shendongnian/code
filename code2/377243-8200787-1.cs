    public class Audit
    {
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public Type ObjectType { get; set; }
        public string Field { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public static void Record(string user, Type objectType, object oldValue, object newValue)
        {
            Audit newEvent = new Audit
            {
                ModifiedBy = user,
                DateModified = DateTime.UtcNow,  // UtcNow avoids timezone issues
                ObjectType = objectType,
                OldValue = oldValue,
                NewValue = newValue
            };
            Save(newEvent);  // implement according to your particular storage classes
        }
    }
