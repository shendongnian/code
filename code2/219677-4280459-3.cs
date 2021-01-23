    <%@ WebHandler Language="C#" Class="ImageHandler" %>
    using System;
    using System.IO;
    using System.Web;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    
    public class ImageHandler : IHttpHandler
    {
    	public void ProcessRequest (HttpContext context)
    	{   
    	    Bitmap output = new Bitmap(path);
    	
    		// Do lots of fun stuff here related to image
    		// manipulation and/or generation
    		
    		...
    		
    	    context.Response.ContentType = ResponseType("Image/png");
    
    	    // Send image to the browser
    	    image.Save(context.Response.OutputStream, ImageType(path));
    	
    	    // Be careful to clean up; you could put this inside a 'using' block	
    	    image.Dispose();
    	}
       
    	public bool IsReusable
    	{
    		get { return true; }
    	}
    }
