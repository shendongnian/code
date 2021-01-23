    class ListboxMenuItems : ObservableCollection<ListboxMenuItem>
    {
        public ListboxMenuItems ()
        {        
            // 'Add' here means 'base.Add'
            Add (new ListboxMenuItem ("Michael", "Anderberg", "12 North Third Street, Apartment 45"));
            Add (new ListboxMenuItem ("Chris", "Ashton", "34 West Fifth Street, Apartment 67"));
            Add (new ListboxMenuItem ("Cassie", "Hicks", "56 East Seventh Street, Apartment 89"));
            Add (new ListboxMenuItem ("Guido", "Pica", "78 South Ninth Street, Apartment 10"));
        }
    }
