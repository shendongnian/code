        class MyWebElement : IWebElement
        {
            private IWebElement _webElementImplementation;
            public IWebElement FindElement(By @by)
            {
                return _webElementImplementation.FindElement(@by);
            }
    
            public ReadOnlyCollection<IWebElement> FindElements(By @by)
            {
                return _webElementImplementation.FindElements(@by);
            }
    
            public void Clear()
            {
                _webElementImplementation.Clear();
            }
    
            public void SendKeys(string text)
            {
                _webElementImplementation.SendKeys(text);
            }
    
            public void Submit()
            {
                _webElementImplementation.Submit();
            }
    
            public void Click()
            {
                _webElementImplementation.Click();
            }
    
            public string GetAttribute(string attributeName)
            {
                return _webElementImplementation.GetAttribute(attributeName);
            }
    
            public string GetCssValue(string propertyName)
            {
                return _webElementImplementation.GetCssValue(propertyName);
            }
    
            public string TagName
            {
                get { return _webElementImplementation.TagName; }
            }
    
            public string Text
            {
                get { return _webElementImplementation.Text; }
            }
    
            public bool Enabled
            {
                get { return _webElementImplementation.Enabled; }
            }
    
            public bool Selected
            {
                get { return _webElementImplementation.Selected; }
            }
    
            public Point Location
            {
                get { return _webElementImplementation.Location; }
            }
    
            public Size Size
            {
                get { return _webElementImplementation.Size; }
            }
    
            public bool Displayed
            {
                get { return _webElementImplementation.Displayed; }
            }
        }
    
