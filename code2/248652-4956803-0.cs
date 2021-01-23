    public partial class FooMaster : System.Web.UI.MasterPage
    {
        // this is originally from the designer-file
        protected global::System.Web.UI.WebControls.ContentPlaceHolder ContentPlaceHolder;
    
        protected override void OnPreRender(System.EventArgs e)
        {
            var fooPageInstance = this.ContentPlaceHolder.BindingContainer as FooPage;
            var fooPropertyInstance = fooPageInstance.fooProperty;
            // TODO do something with the property
        }
    }
