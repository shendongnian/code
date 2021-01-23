    public class DlpItem : IEquatable<DlpItem>
    {
        public string Text { get; set; }
        private readonly int id;
        public int Id { get { return id; } }
    
        public DlpItem(int id)
        {
            Text = "";
            this.id = id;
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as DlpItem);
        }
    
        public bool Equals(DlpItem other)
        {
            return other != null && this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
