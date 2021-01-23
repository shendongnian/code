    public class TemplateParser
    {
    	public static ITemplate ParseTemplate(string content, string virtualPath, bool ignoreParserFilter)
    	{
    		return TemplateParser.ParseTemplate(string content, VirtualPath.Create(virtualPath), ignoreParserFilter);
    	}
    }
