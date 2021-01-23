    using System.Web.UI.WebControls;
    namespace StackOverflowWeb
    {
        public class MultiCastButton : Button
        {
            public ListItemCollection ClickEventList { get; set; }
       
            private void SetEventHandlers()
            {
                // convert listitem values to EventHandler type
                Func<ListItem, EventHandler> getEventHandler = ev =>
                    EventHandler.CreateDelegate(
                        typeof(EventHandler), this.Page, ev.Value) as EventHandler;
                if (ClickEventList != null && ClickEventList.Count > 0)
                {
                    for (var i = 0; i < ClickEventList.Count; i++)
                    { 
                        this.Click += getEventHandler(ClickEventList[i]);
                    }
                }
            }
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
 
                // must occur OnInit because 'this.Page' 
                // is null prior to this event firing
                SetEventHandlers();        
           }
        }
    }
