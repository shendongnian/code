    StringBuilder html = new StringBuilder();
    using (StringWriter stringWriter = new StringWriter(html))
    {
    	using (HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter))
    	{
    		image.RenderControl(textWriter);
    	}
    }
