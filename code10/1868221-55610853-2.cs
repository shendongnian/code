    public class RineItem2
    {
        public string Name2 { get; set; }
        public int Id2 { get; set; }
        public static implicit operator RineItem(RineItem2 o)
        {
            return new RineItem() { Id = o.Id2, Name = o.Name2 };
        }
    }
