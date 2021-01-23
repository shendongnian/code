    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddPanel.Click += new EventHandler(btnAddPanel_Click);
        }
        void btnAddPanel_Click(object sender, EventArgs e)
        {
            TabPanel newPanel = new TabPanel();
            
            newPanel.HeaderTemplate = TemplatePanel.HeaderTemplate;
            TemplatePanel.ContentTemplate.InstantiateIn(newPanel);
            TabContainer1.Tabs.Add(newPanel);
            TabContainer1.ActiveTab = newPanel;        
        }
    }
