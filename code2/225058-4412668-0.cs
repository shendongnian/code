    public class Father
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Children Children { get; set; }
        public Father()
        {
        }
    }
    public class Children : List<Child>
    {
        public Child this[string name]
        {
            get
            {
                return this.FirstOrDefault(tTemp => tTemp.Name == name);
            }
        }
    }
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Child()
        {
        }
    }
