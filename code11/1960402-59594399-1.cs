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
<b>EDIT:</b>
If you want a common interface for the setters that is available only internally, you can do just that:
csharp
// You can probably come up with a better name.
internal interface IExternalBrowserLocatableMutable : IExternalBrowserLocatable
{
    new Point PositionOnDocument { get; set; }
}
internal class ExternalBrowserPuppeteerChromiumSpecificMouse : ExternalBrowserPuppeteerChromiumSpecificModule, IExternalBrowserLocatableMutable
{
    ... 
    public Point PositionOnDocument { get; set; }
}
It's perfectly legal (and very useful!) for a `public` class to implement an `internal` interface, and you can cast the implementing class to either the direct `internal` interface or its `public` base. When accessing through the `internal` interface (or the class itself), you get both the getter and the setter. The `public` interface exposes only the getter.
