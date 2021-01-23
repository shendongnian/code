    public abstract class AuditableTable 
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int TextLength
        {
            get { return this.Text.Length; }
        }
    }
