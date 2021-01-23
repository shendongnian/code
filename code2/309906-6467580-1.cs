    namespace Test
    {
        using System;
        using System.Web.UI;
        using System.Web.UI.WebControls;
    
        public partial class Default : Page
        {
            protected void Page_Load(Object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    this.First.DataSource = null;
    
                    this.First.DataBind();
                }
            }
    
            protected void First_SelectedIndexChanged(Object sender, EventArgs e)
            {
                String selectedValue = (sender as DropDownList).SelectedValue;
    
                // Use dataValue when getting the data for the second drop down.
                this.Second.DataSource = null;
    
                this.Second.DataBind();
            }
    
            protected void Second_SelectedIndexChanged(Object sender, EventArgs e)
            {
                // Do things here.
            }
        }
    }
