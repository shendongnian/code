    public class ApplicationBase : umbraco.BusinessLogic.ApplicationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBase"/> class.
        /// </summary>
        public ApplicationBase()
        {
            Document.New += this.Document_New;
        }
    
        private void Document_New(Document sender, NewEventArgs e)
        {
            sender.getProperty("umbracoUrlName").Value = "your_urlname_here";
            sender.Save();
        }    
    }
