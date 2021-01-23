    public class CustCtl : WebControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            WebControl parent = Parent as WebControl;
            if (parent != null)
            {
                parent.Attributes.Add("key", "value");
            }
        }
    }
