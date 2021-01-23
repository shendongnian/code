    class ListboxMenuItems
    {
        public List<ListboxMenuItem> Items { get; private set; }
    
        public ListboxMenuItems ()
        {        
            Items = new List<ListboxMenuItem> {
                new ListboxMenuItem("Michael", "Anderberg", "12 North Third Street, Apartment 45"),
                new ListboxMenuItem("Chris", "Ashton", "34 West Fifth Street, Apartment 67"),
                new ListboxMenuItem("Cassie", "Hicks", "56 East Seventh Street, Apartment 89"),
                new ListboxMenuItem("Guido", "Pica", "78 South Ninth Street, Apartment 10")
            };
        }
    }
