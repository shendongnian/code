    //clicking links AND get data
    public static void clickAllLinks(string tagName)
    {
        int elements = 
        driver.FindElements(By.xpath("//div[@class='data']//a[contains(.," + tagName + ")]").Count();
        for (int pos = 1; pos < elements; pos++)
        {
            driver.FindElements(By.xpath("(//div[@class='data']//a[contains(.," + tagName + ")])[" +  pos + "]").Click();
            //fetchdata();
        }
    }
