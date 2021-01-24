`
public class Element
{
    public string TagName { get; set; }
    public string Text { get; set; }
    public bool Displayed { get; set; }
    // any other attributes you want to store here
}
public List<Element> StoreWebElements(List<IWebElement> seleniumElements)
{
    var result = new List<Element>();
    foreach (var elem in seleniumElements)
    {
       result.Add(new Element { TagName = elem.TagName,
                                Text = elem.Text, 
                                Displayed = elem.Displayed
                               };
    }
}
        
// your code
var divList = Driver.FindElements(By.Name("elemName"));
// "store" the elements
var cachedElements = StoreWebElements(divList);
// do something on the page to change it 
// divList will change, but cachedElements will stay the same.
`
It's a bit of a hacky solution, but I personally never found a workaround to the issue that you have described. I would be curious to see if anyone else has an explanation or better solution for this.
