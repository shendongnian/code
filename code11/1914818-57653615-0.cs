    public List<IWebElement> ListOfElements()
    {
        var elements = new List<string>();
        return listElements = _driver.FindElements(By.CssSelector(".category-list div[class='cat-prod-row js_category-list-item js_clickHashData js_man-track-event ']");
    }
    public void DisplayFirstElement()
    {
        var allElements = ListOfElements();
        var firstElement = allElements.First();
        Console.WriteLine("FirstName: " + firstElement.Name + " Price: " + firstElement.Price);
    }
