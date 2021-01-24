    public int getTotalNumberOfRows() {
    
        var clickOnNextButton = pageNavigationElement();// clicking on the next arrow key
    
        var numberOfPages = _driver.FindElements(By.XPath("//a[@aria-label]")); //number of pages available like 1 to 7 in my case
    
        int count = 0; // initializing the count
        while (!checkNavigationElementIsDisabled()) {
        for (int i = 0; i <= numberOfPages.Count - 1; i++) {
            var rowsOnPages = verifyPaginationOnSelectedPage(); // 10 rows available in a page
            foreach (var rows in rowsOnPages) {
                count++;
            }
            clickOnNextButton.Click();
            Thread.Sleep(200);
        }
        }
        return count;
    }
