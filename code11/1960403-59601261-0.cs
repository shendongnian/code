csharp
public abstract class BrowserModule
{
    // ExternalBrowser that owns this module.
    protected Browser Browser { get; set; }
    // Underlying specific module => Puppeteer, Selenium or anything.
    protected BrowserModule SpecificModule { get; set; }
		
    public abstract Point PositionOnDocument { get; internal set; }
    ...
}
public class BrowserMouse : BrowserModule
{
    ...
    // This delegates the call to the specific module.
    public override Point PositionOnDocument
    {
        get
        {
            return SpecificModule.PositionOnDocument;
        }
        internal set
        {
            SpecificModule.PositionOnDocument = value;
        }
    }
}
// The specific module implementation that is gonna be called from the main module.
public class BrowserPuppeteerChromiumSpecificMouse : BrowserModule
{
    ...
    public override Point PositionOnDocument { get; internal set; }
}
