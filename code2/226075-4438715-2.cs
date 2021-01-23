    public class MainForm : Form
    {
        private SubForm1 _subForm1;
        private SubForm2 _subForm2;
        
        public MainForm()
        {
            _subForm1 = new SubForm1();
            _subForm2 = new SubForm2();
    
            _subForm1.ClientUpdated += new EventHandler(_subForm1_ClientUpdated);
            _subForm2.ClientUpdated += new EventHandler(_subForm2_ProductUpdated);
        }
    
        private void _subForm1_ClientUpdated(object sender, EventArgs e)  
        {
            txt_ClientName.Text = _subForm1.ClientName; // Expose a public property
        }
    
        private void _subForm2_ProductUpdated(object sender, EventArgs e)  
        {
            txt_ProductName.Text = _subForm2.ProductName; // Expose a public property
        }
    }
