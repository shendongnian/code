    public class Contact
    {
        public int Id {get; set;}
        public ICollection<ContactCategory> ContactCategories {get; set;}
    }
    public class Category
    {
        public int Id { get; set; }
        public ICollection<ContactCategory> ContactCategories { get; set; }
    }
    public class ContactCategory
    {
        public int Id { get; set; }
        public int ContactId {get; set;}
        public Contact Contact {get; set;}
        public int CategoryId {get; set;}
        public Category Category {get; set;}
    }
