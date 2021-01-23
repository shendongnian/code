    using System.IO;
    using System.Web;
    public class MyImageHandler : IHttpHandler 
    {
        public void ProcessRequest(System.Web.HttpContext ctx) 
        {
    		
    		string _Path;
    		
    		_Path = "E:\\XYZ\\11-01-01 New Year\\" + Convert.ToString(context.Request.QueryString["image"]);
    		
    		ctx.Response.StatusCode = 200;
    		ctx.Response.ContentType = "image/jpeg";
    		ctx.Response.WriteFile(_Path);		
        }
     
    	public bool IsReusable { get {return true; } }        
     }
