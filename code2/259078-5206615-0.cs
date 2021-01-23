    public partial class frmGridWithRowLimit : Form
    {
        public Int32 MaxRows { get; set; }
    
        public frmGridWithRowLimit()
        {
            MaxRows = 10;
    
            InitializeComponent();
    
            dgRowLimit.UserAddedRow += dgRowLimit_RowCountChanged;
            dgRowLimit.UserDeletedRow += dgRowLimit_RowCountChanged;
        }
    
        private void dgRowLimit_RowCountChanged(object sender, EventArgs e)
        {
            CheckRowCount();
        }
    
        private void CheckRowCount()
        {
            if (dgRowLimit.Rows != null && dgRowLimit.Rows.Count > MaxRows)
            {
                dgRowLimit.AllowUserToAddRows = false;
            }
            else if (!dgRowLimit.AllowUserToAddRows)
            {
                dgRowLimit.AllowUserToAddRows = true;
            }
        }
    }
