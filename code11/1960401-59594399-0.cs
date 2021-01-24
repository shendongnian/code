interface IExternalBrowserLocatable
{
    Point PositionOnDocument { get; }
} 
If you want a setter accessible internally, make its visibility `internal`.
internal class ExternalBrowserPuppeteerChromiumSpecificMouse : ExternalBrowserPuppeteerChromiumSpecificModule, IExternalBrowserLocatable
{
    ... 
    public Point PositionOnDocument { get; internal set; }
}
