    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
        public override string ToString()
        {
            return Parent == null 
                ? Name
                : string.Format("{0} > {1}", Parent, Name);
        }
    }
