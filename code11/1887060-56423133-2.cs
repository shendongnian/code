    public class UserAccount
    {
        // This will be serialized
        public int Id { get; set; }
        // This may (or may not) be be serialized depending on your condition
        public string Name { get; set; }
        // This also may (or may not) be be serialized depending on your condition
        public string Email { get; set; }
        // ShouldSerialize<PropertyName>
        public bool ShouldSerializeName()
        {
            if(someCondition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ShouldSerialize<PropertyName>
        public bool ShouldSerializeEmail()
        {
            if(someCondition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
