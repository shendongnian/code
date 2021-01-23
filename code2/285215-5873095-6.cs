    public abstract class ApplicationViewPage<T> : WebViewPage<T>
        {
            protected override void InitializePage()
            {
                SetViewBagDefaultProperties();
                base.InitializePage();
            }
    
            private void SetViewBagDefaultProperties()
            {
                ViewBag.LayoutModel = new LayoutModel(Request.ServerVariables["SERVER_NAME"]);
            }
    
        }
