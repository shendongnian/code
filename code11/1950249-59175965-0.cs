wait.Until(ExpectedConditions.ElementToBeClickable(_formNetworkFormControl));
doesn't cover this case.
I fixed it with updating Page class following way:
public IWebElement IsElementHasTrueAriaDisabledAttribute(IWebDriver webdriver, IWebElement element)
{
    if (element.GetAttribute("aria-disabled").Equals("false"))
    {
        return element;
    }
    return null;
}
public void ClickFormNetworkFormControl(IWebDriver webdriver)
{
    WebDriverWait wait = new WebDriverWait(webdriver, timeout: TimeSpan.FromSeconds(15));
    wait.Until<IWebElement>((d) => 
    {
        return IsElementHasTrueAriaDisabledAttribute(d, _formNetworkFormControl);
    });
    _formNetworkFormControl.Click();
}
