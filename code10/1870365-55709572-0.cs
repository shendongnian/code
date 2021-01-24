 csharp
  [ContentProperty(nameof(HtmlContent))]
  public class WasmHtmlContentControl : Control
  {
    public WasmHtmlContentControl()
     : base(htmlTag: "div") // the root HTML tag of your content
    {
    }
    private string _html;
    public string HtmlContent
    {
      get => _html;
      set
      {
        base.SetHtmlContent(html); // this is a protected method on Wasm target
        _html = value;
      }
    }
  }
And the XAML:
 xml
  <ctl:WasmHtmlContentControl>
    <!-- xml encoded html -->
    &lt;h1&gt;It works!&lt;/h1&gt;
  </ctl:WasmHtmlContentControl>
Maybe a `<![CDATA[` ... `]]>` could work... never tried.
