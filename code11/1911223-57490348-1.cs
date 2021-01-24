    public IActionResult DoSomething()
    {
        return new  JavaScriptResult("alert('Hello world!');");
    }
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script)
        {
            this.Content = script;
            this.ContentType = "application/javascript";
        }
    }
