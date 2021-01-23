    [ParseChildren(typeof(OverrideContent), DefaultProperty = "OverrideItems", ChildrenAsProperties=true)]
    public partial class XmlRenderSource : System.Web.UI.UserControl
    {
        private OverrideContentCollection overrideItems = new OverrideContentCollection();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public OverrideContentCollection OverrideItems
        {
            get { return overrideItems; }
        }
    }
