    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
 
    //button click event
    protected void btnTemp_Click(object sender, EventArgs e) {
        // get button object
        Button btn = (Button)sender;
              
        //Set clicked button text
        btn.Text = "Clicked";         
       //If you want set parent control then
       //find parent control and set value
       ((HtmlAnchor) btn.Parent.FindControl("Parent")).InnerText = "Parent";
      
    }
