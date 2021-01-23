    public class YourTemplate : ITemplate 
    {
        public void InstantiateIn(Control container)
        {
            container.Controls.Add(new LiteralControl("test"));
        }
    }
    
    ...
    upnl.ContentTemplate = new YourTemplate();
