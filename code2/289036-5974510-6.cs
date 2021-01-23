    public class AspExceptionHandler : IHttpModule, IHttpHandler
    	{
    		public void Dispose() { }
    
    		public void Init(HttpApplication context)
    		{
    			context.Error += new EventHandler(ErrorHandler);
    		}
    
    		private void ErrorHandler(object sender, EventArgs e)
    		{
    			HttpApplication application = (HttpApplication)sender;
    			try
    			{
    				// Gather information
    				Exception currentException = application.Server.GetLastError(); ;
    				String errorPage = "http://companywebsite.be/error.aspx";
    
    				HttpException httpException = currentException as HttpException;
    				if (httpException == null || httpException.GetHttpCode() != 404)
    				{
    					application.Server.Transfer(errorPage, true);
    				}
    				//The error is a 404
    				else
    				{
    					// Continue
    					application.Server.ClearError();
    
    					String shouldMail404 = true;
    
    					//Try and redirect to the proper page.
    					String requestedFile = application.Request.Url.AbsolutePath.Trim('/').Split('/').Last();
    
    					// Redirect if required
    					String redirectURL = getRedirectURL(requestedFile.Trim('/'));
    					if (!String.IsNullOrEmpty(redirectURL))
    					{
    						//Redirect to the proper URL
    					}
    					//If we can't redirect properly, we set the statusCode to 404.
    					else
    					{
    						//Report the 404
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				ExceptionCatcher.FillWebException(HttpContext.Current, ref ex);
    				ExceptionCatcher.CatchException(ex);
    			}
    		}
    
    		public bool IsReusable
    		{
    			get { return true; }
    		}
    
    		public void ProcessRequest(HttpContext context)
    		{
    			if (!File.Exists(context.Request.PhysicalPath)) 
    			{
    				throw new HttpException(404, String.Format("The file {0} does not exist", context.Request.PhysicalPath));
    			}
                        else
    			{
    				context.Response.TransmitFile(context.Request.PhysicalPath);
    			}
    		}
    	}
