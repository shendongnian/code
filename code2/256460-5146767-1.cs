    public class AccessRequestViewModel
    {
        private AccessRequesetViewModel() { };
        public static GetAccessRequestViewModel (List<Person> persons)
        {
                return new AccessRequestViewModel()
                {
                    Persons = persons,
                };
        }
        public Request Request { get; private set; }
        public SelectList Buildings { get; private set; }
        public List<Person> Persons { get; private set; }
    }
