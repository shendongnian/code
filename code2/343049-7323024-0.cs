    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RadioButton runat=server></{0}:RadioButton>")]
    public class RadioButton : System.Web.UI.WebControls.RadioButton
    {
        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        public string Value
        {
            get
            {
                string RadioValue = (string)ViewState["Value"];
                return (RadioValue == null) ? String.Empty : RadioValue;
            }
            set
            {
                ViewState["Value"] = value;
            }
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
