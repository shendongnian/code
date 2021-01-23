    using System;
    using System.Windows.Forms;
    
    namespace Testing
    {
        public partial class TestForm : Form
        {
            public TestForm()
            {
                InitializeComponent();
    
                Load += TestForm_Load;
    
                VisibleChanged += TestForm_VisibleChanged;
    
                Shown += TestForm_Shown;
                Show();
    
            }
    
            private void TestForm_Load(object sender, EventArgs e)
            {
                MessageBox.Show("This event is called before the form is rendered.");
            }
    
            private void TestForm_VisibleChanged(object sender, EventArgs e)
            {
                MessageBox.Show("This event is called before the form is rendered.");
            }
    
            private void TestForm_Shown(object sender, EventArgs e)
            {
                MessageBox.Show("This event is called after the form is rendered.");
                txtFirstName.Focus();
            }
        }
    }
