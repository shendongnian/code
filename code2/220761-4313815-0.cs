    public class Person
    {
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public ObservableCollection<AccountDetail> Details
        {
            get { return details; }
            set { details = value; }
        }
        public ObservableCollection<AccountDetail> Phones
        {
            get
            {
                if (phones == null)
                {
                    phones = new ObservableCollection<AccountDetail>();
                }
                phones.Clear();
                foreach (AccountDetail detail in Details)
                {
                    if (detail.Type == DetailType.Phone)
                    {
                        phones.Add(detail);
                    }
                }
                return phones;
            }
            set
            {
                phones.Clear();
                foreach (var item in value)
                {
                    phones.Add(item);
                }
                foreach (AccountDetail detail in Details)
                {
                    if (detail.Type == DetailType.Phone)
                    {
                        Details.Remove(detail);
                    }
                }
                foreach (AccountDetail detail in phones)
                {
                    if (!string.IsNullOrEmpty(detail.Value))
                    {
                        Details.Add(detail);
                    }
                }
            }
        }
        private string firstName;
        private string lastName;
        private ObservableCollection<AccountDetail> details;
        public ObservableCollection<AccountDetail> phones;
    }
