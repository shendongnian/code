    [ParseChildren(typeof(WebControl), ChildrenAsProperties = true, 
        DefaultProperty = "ChildControls"), NonVisualControl]
    public class EnableGroup: Control
    {
            public EnableGroup() {
                 ChildControls = new Collection<WebControl>();
            }
    
            protected override void OnPreRender(EventArgs e)
            {
                foreach (WebControl ctl in Controls) {
                    ctl.Enabled = this.Enabled;
                }
                base.OnPreRender(e);
            }
    
            public Collection<WebControl> ChildControls
            {
                get; 
                protected set;
            } 
    }
