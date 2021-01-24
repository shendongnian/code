    public class Role
    {
        public Role(string name, int value)
        {
            Name = name;
            Value = value;
            SubRoles = new List<SubRole>();
        }
        public string Name { get; set; }
        public int Value { get; set; }
        public List<SubRole> SubRoles { get; set; }
        public enum SubRoleType
        {
            Red = 1,
            Orange = 2,
            Green = 3
        }
    }
    public class SubRole
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public SubRole(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
