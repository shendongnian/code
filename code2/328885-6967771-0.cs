    using System;
    using System.Web;
    using System.IO;
    public class Upload : IHttpHandler 
    {   
    	public void ProcessRequest(HttpContext context) 
    	{   
    		string path = HttpContext.Current.Server.MapPath("/client/vault/" 
    			+ Helpers.CurrentClientHash(context.Session["SessionHash"].ToString()) 
    			+ "/users/" + context.Session["SessionHash"].ToString() 
    			+ "/");
    			
    		HttpPostedFile oFile = context.Request.Files[context.Request["params"]];        
    		if (!Directory.Exists(path)) Directory.CreateDirectory(path);		
    		oFile.SaveAs(path + oFile.FileName);     
    		     
    		context.Response.Write("1");   
    	}   
    	public bool IsReusable 
    	{      
    		get { return true; }   
    	}
    }
