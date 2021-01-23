    using System;
    namespace MyProject.UI
    {
      public partial class test : System.Web.UI.Page
      {
         protected void Page_Load(object sender, EventArgs e)
         {
         }
         protected void btnPost_Click(object sender, EventArgs e)
         {
            lblMessage.Text = tdHere.InnerHtml;
         }
      }
    }
