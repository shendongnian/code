    using System;
    using System.Web;
    
    public class GenerateXML : IHttpHandler
    {
    	public bool IsReusable {
    		get { return true; }
    	}
    
    	public void ProcessRequest(HttpContext context) {
    		var resp = context.Response;
    
    		resp.ContentType = "text/xml";
    		resp.ContentEncoding = System.Text.Encoding.UTF8;
    
    		resp.Write( "<xml>i am xml</xml>" );
    	}
    }
