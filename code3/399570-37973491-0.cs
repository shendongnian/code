    public static void SelectOptionFromDropdown(this IWebDriver driver,IWebElement dropdown, SelectBy selectBy, string item)
        {
            switch (selectBy)
            {
                case SelectBy.Index:
                    int index;
                    if (Int32.TryParse(item, out index))
                    {
                        new SelectElement(dropdown).SelectByIndex(index);
                    }
                    else
                    {
                        ExceptionHandler.LogException("Unable to Convert String To Int", "WebdriverExtension", "SelectOptionFromDropdown");
                        throw new Exception();
                    }
                    
                    break;
                case SelectBy.Text:
                    new SelectElement(dropdown).SelectByText(item);
                    break;
                case SelectBy.Value:
                    new SelectElement(dropdown).SelectByValue(item);
                    break;
            }
        }
