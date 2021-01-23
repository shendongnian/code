    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomTextBox runat=server></{0}:CustomTextBox>")]
    public class CustomTextBox: System.Web.UI.WebControls.TextBox
    {
        [Bindable(true)]
        [DefaultValue("")]
        public string Something
        {
            get
            {
                string something = (string)ViewState["Something"];
                return (something == null) ? String.Empty : something ;
            }
            set
            {
                ViewState["Something"] = value;
            }
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
