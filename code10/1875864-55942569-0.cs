    string aa = driver.FindElement(By.XPath("//*[@id='FRMcommissionupdate']/div[7]/div")).Text;
    var result = new string(aa.SkipWhile(x => 
                           !char.IsDigit(x)).TakeWhile(char.IsDigit).ToArray());
    return result;
   
   
