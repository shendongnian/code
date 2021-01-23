        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            Follow();
            if (!IsBusy && Url == e.Url && ReadyState == WebBrowserReadyState.Complete)
            {
                Document.Window.AttachEventHandler("onscroll", DocScroll);
            }
        }
