    public class MyCustomButton : Button
    {
    	protected override void AddAttributesToRender(HtmlTextWriter writer)
    	{
    		base.AddAttributesToRender(writer);
    		writer.AddAttribute("onclick", "myJavascriptFunction('a string');", false); // passing false to the AddAttribute method tells it not to encode this attribute.
    	}
    }
