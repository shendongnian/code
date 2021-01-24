    public class Item
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Id == (obj as Item)?.Id;
        }
    }
