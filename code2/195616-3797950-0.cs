    [ToolboxData("<{0}:SmartRepeater runat=\"server\"></{0}:SmartRepeater>")]
    public partial class SmartRepeater : Repeater
    {
    	public bool ShowHeaderOnEmpty { get; set; }
    	public bool ShowFooterOnEmpty { get; set; }
    
    	private ITemplate emptyTemplate = null;
    	
    	[PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate EmptyTemplate
        {
            get { return this.emptyTemplate; }
            set { this.emptyTemplate = value; }
        }
    
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (this.Items.Count == 0)
            {
                this.Controls.Clear();
    
    			if (this.HeaderTemplate != null && ShowHeaderOnEmpty)
    				this.HeaderTemplate.InstantiateIn(this);
    			
    			if (this.EmptyTemplate!=null)
    				this.EmptyTemplate.InstantiateIn(this);
    
    			if (this.FooterTemplate != null && ShowFooterOnEmpty)
    				this.FooterTemplate.InstantiateIn(this);
    		}
        }
    }
