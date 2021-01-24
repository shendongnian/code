    private void CombineFirstAndLastname<TRole>(object sender, ListControlConvertEventArgs e)
        where TRole : IFullname
    {
        var role = (TRole)e.ListItem;
        e.Value = $"{role.Name} {role.LastName}"
    }
    
    public interface IFullname
    {
        string Name { get; }
        string LastName { get; }
    }
    public class Director : IFullname
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    
    public class Actor : IFullname
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
