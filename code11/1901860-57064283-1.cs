    public class DbViewModel
    {
             public long TotalClients { get; set; }
        public long FilteredCLients { get; set; }
		public List<Client> Clients{ get; set; }
        public List<int> AssociatedClientIds { get; set; }
    }
	public class Client
	{
        
        public Client() {}
		public ClientLink ClientLink { get; set; }
        public const string LastNameDisplayName = "Last Name";
        public const int    LastNameMaxLength    =  100;
        public const string LastNameMaxLengthStr = "100";
        //[MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }
        public const string FirstNameDisplayName = "First Name";
        public const int    FirstNameMaxLength    =  30;
        public const string FirstNameMaxLengthStr = "30";
        //[MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }
        public const string MiddleNameDisplayName = "Middle Name";
        public const int    MiddleNameMaxLength    =  30;
        public const string MiddleNameMaxLengthStr = "30";
        //[MaxLength(MiddleNameMaxLength)]
        public string MiddleName { get; set; }
        public const string SuffixDisplayName = "Suffix";
        public const int    NameSuffixMaxLength    =  10;
        public const string NameSuffixMaxLengthStr = "10";
        //[MaxLength(NameSuffixMaxLength)]
        public string NameSuffix { get; set; }
     
        public string FullName
        {
            get
            {
                return NameFormatter.Format(LastName, FirstName, MiddleName, NameSuffix);
            }
        }
       
    }
	public class ClientLink  
    {
        public long ClientId { get; set; }
        private List<ClientAddress> address = new List<ClientAddress>();
        public ClientLink()
        {
        }      
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<DbModel> dbModels = DbModel.GetModels();
            List<DbViewModel> viewModels = dbModels.GroupBy(x => x.first_name.ToLower() + ' ' + x.last_name.ToLower()).Select(fullNameGrouping =>
                new DbViewModel()
                {
                    full_name = fullNameGrouping.Key,
                    clientIds = fullNameGrouping.Select(x => x.clientId).ToList()
                }).ToList();
            Console.ReadKey();
        }
    }
