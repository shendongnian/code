    [ControlBuilder(typeof(RebasingContainerBuilder)),
      Designer("System.Web.UI.Design.ControlDesigner, System.Design, " +
      "Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
      ConstructorNeedsTag(false)]
    public class RebasingContainer : HtmlGenericControl
    {
        public RebasingContainer()
        {
    
        }
    
        protected override void RenderBeginTag(System.Web.UI.HtmlTextWriter writer)
        {  /*doesn't render it's own tag*/ }
    
        protected override void RenderEndTag(System.Web.UI.HtmlTextWriter writer)
        {/*doesn't render it's own tag*/}
    }
