    public class AccessRequestViewModel
    {
        public Request Request { get; private set; }
        public SelectList Buildings { get; private set; }
        [AtLeastOneItem]
        public List<Person> Persons { get; private set; }
    }
