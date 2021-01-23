    String location = Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyAssembly.Javascript.MyJavascript.js");
    
    StringBuilder startup = new StringBuilder(String.Empty);
    startup.Append(@"<script type='text/javascript'");
    startup.Append(" src='" + location + "'>");
    startup.Append("</script>");
    
    Page.Header.Controls.Add(new LiteralControl(startup.ToString()));
