public static class WebElementSupport 
{
    public static void ClickElement(this IWebElement element) 
    {
        //implementation
    }
}
and then use it by just `using` the class with extensions
using Namespace.With.Extension.WebElementSupport;
public class HomePage
{
    public void ClickOnThatElement()
    {
        Element.ClickElement();
    }
}
