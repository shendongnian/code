    public interface IEditAccount
    {
        // you can change the type.
        // Save Click Event
        void Save(string someData);
    
        // Cancel Event
        void Cancel();
    }
    public partial class frmAccountDetails : Form
    {
        public IEditAccount EditAccount { set; }
    
        public frmAccountDetails()
        {
            InitializeComponent();
        }
    
        private void btnSave_Click_Click(object sender, EventArgs e)
        {
            EditAccount.Save("Some Data");
        }
    }
    public partial class frmCustomers : Form, IEditAccount
    {
        public frmCustomers()
        {
            InitializeComponent();
        }
    
        private void DisplayAccountDetails(object sender, EventArgs e)
        {
            var form = new frmAccountDetails();
            form.EditAccount = this;
            form.Show();
        }
    
        public void Save(string someData)
        {
            // When user click the frmAccountDetails.btnSave_Click_Click you can get the someData
            // Save the someData to the database  
        }
    
        public void Cancel()
        {
            // user click the cancel
        }
    }
