    public class testB : System.Web.UI.UserControl
    {
        public System.Web.UI.WebControls.PlaceHolder plc { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            if (plc != null)
            {
                this.AppRelativeTemplateSourceDirectory =
                        plc.AppRelativeTemplateSourceDirectory;
                this.Controls.Add(plc);
            }
            base.OnLoad(e);
        }
    }
