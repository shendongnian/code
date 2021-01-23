    public class NameAndAddress
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public NameAndAddress(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
    public List<NameAndAddress> GetObjects()
    {
        return (from w in db.Widgets
            where w.widget_id == 1
            select new NameAndAddress(w.name, w.address)
        ).ToList();
    }
