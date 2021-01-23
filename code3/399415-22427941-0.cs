            main form: 
            
            private void Button2_Click(object sender, EventArgs e) {
             frmCustomersRecord rec = new frmCustomersRecord(this); 
        rec.ShowDialog();
             rec.GetData(); 
            }
            
            child form: public partial class frmCustomersRecord : Form 
            { 
            public frmCustomersRecord()
            {
            //blank contructor (Instance of an class)
            }
             frmCustomerDetails cd;
             public frmCustomersRecord(frmCustomerDetails parentForm) : this()
            {
             this.cd = parentForm; 
            } 
               //call the methods using child form object
    
        
        }
