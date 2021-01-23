    using System.Collections.Generic;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    
    public class Form1 : Form
    {
        public Form1()
        {
          
            var lookUpEdit1 = new LookUpEdit();
            Controls.Add(lookUpEdit1);
            
            var source = new List<string>();
            for (var i = 0; i < 10;i++ )
                source.Add(i.ToString());
            lookUpEdit1.Properties.DataSource = source;
            lookUpEdit1.EditValue = "4";
        }
    
    }
