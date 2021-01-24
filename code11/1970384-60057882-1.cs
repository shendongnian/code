    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    string strText=wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//center[@id='genelUyariCenterTag' and contains(.,'BULUNAMAMIŞTIR')]"))).Text;
        if (strText.Contains("LİSTELENECEK VERİ BULUNAMAMIŞTIR."))
                {
                    Console.WriteLine("madde15 there is no Excel");
                }
         else
                {
                    Console.WriteLine("madde 15 there is an Excel");
                 }
