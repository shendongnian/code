    // Presumed to be in Page class
    [FindsBy(How = How.Id, Using = "ButtonId")]
    public IWebElement submitButton { get; set; }
    
    // Presumed to be in Helpers class
    public void ScrollToElementOnPage(IWrapsElement element) 
    { 
       var js = driver as IJavaScriptExecutor;
    return  js.ExecuteScript("arguments[0].scrollIntoView(true);",element.WrappedElement);
    }
    
    Helpers _helpers = new Helpers();
    Page _page = new Page();
    _helpers.ScrollToElementOnPage((IWrapsElement)_page.submitButton);
