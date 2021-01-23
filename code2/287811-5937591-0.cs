        HtmlHelper _htmlHelper;
        public HtmlHelper HtmlHelper
        {
            get 
            {
                if (_htmlHelper == null)
                {
                    TextWriter writer = new StringWriter();
                    _htmlHelper = new HtmlHelper(new ViewContext(ControllerContext,
                        new WebFormView("Default"),
                        new ViewDataDictionary(),
                        new TempDataDictionary(), writer), new ViewPage());
                }
                return _htmlHelper;
            }
        }
