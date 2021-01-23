    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    public partial class Test : Page
    {
        private CheckBox MyCheckBox { get; set; }
        protected override void CreateChildControls()
        {
            
            this.MyCheckBox = new CheckBox() { Checked = true };
            this.ph.Controls.Add(this.MyCheckBox);
            base.CreateChildControls();
        }
    
        protected void btn_Click(object sender, EventArgs e)
        {
            var someValue = this.MyCheckBox.Checked;
            this.lbl.Text = someValue ? "Checked" : "Not Checked";
        }
    
    }
