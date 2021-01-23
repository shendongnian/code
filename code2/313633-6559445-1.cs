    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace DenemeWebApplication
    {
        public partial class DenemeWebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                DropDownList dropdownlistAmk = new DropDownList();//creates a new dropdownlist
                dropdownlistAmk.Items.Add("amk");//adds an item to dropdownlistAmk created above
                PanelAmk.Controls.Add(dropdownlistAmk);//and adds dropwdownlistAmk to PanelAmk
                
            }
        }
    }
