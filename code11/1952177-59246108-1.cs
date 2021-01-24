    ```
    public class MyViewComponentContext 
    {
        public HttpContext HttpContext { get; set; }
        public ActionContext ActionContext { get; set; }
        public ViewDataDictionary ViewData { get; set; }
        public ITempDataDictionary TempData { get; set; }
    }
    private async Task<string> Render( MyViewComponentContext myViewComponentContext,string viewComponentName,object args) {
        using (var writer = new StringWriter())
        { 
            var helper = this.GetViewComponentHelper(myViewComponentContext, writer);
            var result = await helper.InvokeAsync(viewComponentName, args);  // get an IHtmlContent
            result.WriteTo(writer, HtmlEncoder.Default);
            await writer.FlushAsync();
            return writer.ToString();
        }
    }
    ```
