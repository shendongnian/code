    public partial class frmPersonnelVerified : System.Web.UI.Page 
    { 
        protected void Page_Load(object sender, EventArgs e) 
        { 
            //Inputs information from frmPersonnel and places it into the  
            //textbox called "txtVerifiedInfo" 
            txtVerifiedInfo.Text = Request["txtFirstName"] + 
                "\n" + Session["txtLastName"] + 
                "\n" + Session["txtPayRate"] + 
                "\n" + Session["txtStartDate"] + 
                "\n" + Session["txtEndDate"]; 
    
        } 
    
    }
