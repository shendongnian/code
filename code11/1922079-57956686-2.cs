try
{
	webDriver.FindElement(By.Id(id));
}
catch(NoSuchElementException)
{
}
Or use array, since finding multiple elements do not cause exception, just empty array.
IWebElement[] elements = webDriver.FindElements(By.Id(id)).ToArray();
if (elements.Count() != 0)
{
	do what you want
}
 
