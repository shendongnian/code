    protected void DoSomething(Control control)(
    {
        foreach (Control c in control.Controls)
        { 
            if(typeof(c).Equals(Telerik.Web.UI.RadEditor))
            {
               Telerik.Web.UI.RadEditor rad = c as Telerik.Web.UI.RadEditor;
               rad.CssClass = "MyStyle";
                  label1.Visible = true; label1.Text = "dhchk";
               // control.CssFiles.Add("~/styles/myStyle.css"); 
            }
            else
            {
                  DoSomething(c);
            }
        }
    }
