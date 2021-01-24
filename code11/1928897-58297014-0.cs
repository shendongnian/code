    public bool IsNotDisplayed(WindowsElement element)
    {
        try
        {
            Assert.IsFalse(element.Displayed, $"Element: {element} is not displayed on the page!");
            return false;
        }
        catch (Exception e)
        {
            // do nothing and it will continue your script.
        }
    }
