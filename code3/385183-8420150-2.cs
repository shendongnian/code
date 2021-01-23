    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    	// This could mess up HTML.
    	string text = "you & me > them"; // 1
    	// Replace > with >
    	string htmlEncoded = Server.HtmlEncode(text); // 2
    	// Now has the > again.
    	string original = Server.HtmlDecode(htmlEncoded); // 3
    	// This is how you can access the Server in any class.
    	string alsoEncoded = HttpContext.Current.Server.HtmlEncode(text); // 4
    	StringWriter stringWriter = new StringWriter();
    	using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
    	{
    	    // Write a DIV with encoded text.
    	    writer.RenderBeginTag(HtmlTextWriterTag.Div);
    	    writer.WriteEncodedText(text);
    	    writer.RenderEndTag();
    	}
    	string html = stringWriter.ToString(); // 5
        }
    }
**
