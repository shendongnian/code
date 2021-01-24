    public class E : VisualCommanderExt.IExtension
    {
    	public void SetSite(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package)
    	{
            this.DTE = DTE;
            events = DTE.Events;
            windowEvents = events.WindowEvents;
            windowEvents.WindowActivated += OnWindowActivated;
    
            documentEvents = events.DocumentEvents;
            documentEvents.DocumentOpened += OnDocumentOpened;
        }
    
        public void Close()
    	{
            windowEvents.WindowActivated -= OnWindowActivated;
            documentEvents.DocumentOpened -= OnDocumentOpened;
        }
    
        private void OnDocumentOpened(EnvDTE.Document Document)
        {
            try
            {
                documentOpened = true;
            }
            catch (System.Exception)
            {
            }
        }
    
        private void OnWindowActivated(EnvDTE.Window gotFocus, EnvDTE.Window lostFocus)
        {
            try
            {
                if (documentOpened)
                    DTE.ExecuteCommand("Edit.CollapsetoDefinitions");
                documentOpened = false;
            }
            catch (System.Exception)
            {
            }
        }
    
        private EnvDTE80.DTE2 DTE;
        private EnvDTE.Events events;
        private EnvDTE.WindowEvents windowEvents;
        private EnvDTE.DocumentEvents documentEvents;
        private bool documentOpened;
    }
