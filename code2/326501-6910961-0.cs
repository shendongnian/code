    public partial class BaseFormControl : System.Web.UI.UserControl
    {
    
    
    
    [TemplateContainer(typeof(ContentContainer))]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    [TemplateInstance(TemplateInstance.Single)]
    public ITemplate Content { get; set; }
    ...
