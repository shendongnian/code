    public class NotAnEntity 
    {
        public Contact { get; set; }
        public static implicit operator Contact(NotAnEntity other)
        {
            return other.Contact;
        }
    }
