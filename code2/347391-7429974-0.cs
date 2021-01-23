        namespace X_Ray
{
    public partial class frmSWChange : Form
    {
        
        public frmSWChange()
        {
            InitializeComponent();
           frmSWChange1
        }
        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            new frmMainMenu().Show();
            this.Close();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            
            string shiftChangeValue;
            label1.Text = mtxtScrapDate.Text;
            derpderp1 = cbShift.SelectedText;
            xRayData xRayData1 = new xRayData();
            
            shiftChangeValue = xRayData1.shiftChange();
            label2.Text = shiftChangeValue;
        }
    }
