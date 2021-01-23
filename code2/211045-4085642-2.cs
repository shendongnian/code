    foreach (Control c in ContentPlaceHolder1.Controls)
    { 
         if(typeof(c).Equals(Telerik.Web.UI.RadEditor))
         {
             Telerik.Web.UI.RadEditor rad = c as Telerik.Web.UI.RadEditor;
    
             label1.Visible = true; label1.Text = "dhchk";
             rad.CssFiles.Add("~/styles/myStyle.css"); 
             rad.CssFiles.Add("~/styles/myStyle2.css");
             rad.CssFiles.Add("~/styles/myStyle3.css");
          }            
          else
          {
             DoSomething(c);
          }
    
     }
