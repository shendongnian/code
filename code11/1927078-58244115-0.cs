            private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
            {
              ThisAddIn addin = ThisAddIn.getInstance();
              if (addin != null )
              {
                addin.Application.DocumentOpened += Application_DocumentOpened;
              }
          }
        private void Application_DocumentOpened(Visio.Document doc)
        {
            if (doc.Application != null)
            {
                Visio.EApplication_WindowTurnedToPageEventHandler appHandler = new Visio.EApplication_WindowTurnedToPageEventHandler(Application_WindowTurnedToPage);
                doc.Application.WindowTurnedToPage += appHandler;
            }
        }
