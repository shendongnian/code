    public static class extensions {
	    public static void myRenderEndTag (this HtmlTextWriter writer) {
		    writer.RenderEndTag();
		    writer.WriteLine();
	    }
    }
