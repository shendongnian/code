     public delegate void OnSearch(string employeeName);
    public partial class Form2 : Form
    {
        public event OnSearch OnSearchClick;
        protected virtual void FireEvent(string employeeName)
        {
            if (OnSearchClick != null)
            {
                OnSearchClick(employeeName);
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmp.Text;
            FireEvent(employeeName);
            this.Close();
        }
    }
