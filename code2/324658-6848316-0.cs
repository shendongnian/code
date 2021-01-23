    public class NoteLink
    {
        // ...
    
        public NoteLink()
        {
            _noteLinkDetails = new List<NoteLinkDetail>();
        }
    
        public class NoteLinkDetail
        {
            public string L { get; set; }
            public string R { get; set; }
        }
    }
