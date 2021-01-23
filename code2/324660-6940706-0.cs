    public partial class BaseFormControl : System.Web.UI.UserControl
        {
    
    
    
            [TemplateContainer(typeof(ContentContainer))]
            [PersistenceMode(PersistenceMode.InnerProperty)]
            [TemplateInstance(TemplateInstance.Single)] //IMPORTANT, makes controls visible in page code-behind
            public ITemplate Content { get; set; }
    
    
    
       void Page_Init()
            {
    
    
    
    
                if (Content != null)
                {
                    ContentContainer cc = new ContentContainer();
                    Content.InstantiateIn(cc);
                    contentHolder.Controls.Add(cc);
                }
            }
