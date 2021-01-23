    public partial class Window1 : Window
    {
        public Window1() 
        {
            AccountDetailsProperty = new List<AccountDetail>()
            {
                new AccountDetail(DetailScope.Business, "Business"),
                new AccountDetail(DetailScope.OtherDetail, "Other details"),
                new AccountDetail(DetailScope.Private, "Private"),
            };
    
            InitializeComponent();
            this.DataContext = this;
        }
    
        public List<AccountDetail> AccountDetailsProperty { get; set; }
    }
