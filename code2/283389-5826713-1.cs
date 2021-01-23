    public partial class MyClass : System.Web.UI.Page
      {
          protected void Page_Load(object sender, EventArgs e)
          {
              GhostForm mainForm = new GhostForm();
              mainForm.RenderFormTag = false;
                .....    
          }
              // Upload your file, etc.
          .....
      }
