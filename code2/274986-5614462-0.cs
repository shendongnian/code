	public static class CustomErrorsFixer
	{
		static public void HandleErrors(HttpContext Context)
		{
			if(RunIt(Context)==false){
				return;
			}
			HttpException ex = Context.Error as HttpException;
			if(ex==null){
				try{
					ex=Context.Error.InnerException as HttpException;
				}catch{
					ex=null;
				}
			}
			
			if (ex != null){
				Context.Response.StatusCode = ex.GetHttpCode();
			}else{
				Context.Response.StatusCode = 500;
			}
			Context.ClearError();
			
			Context.Server.Transfer(GetCustomError(Context.Response.StatusCode.ToString()));
			HttpContext.Current.Response.End();
		}
		static protected string GetCustomError(string code)
		{
		    CustomErrorsSection section = ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
		
		    if (section != null)
		    {
			    CustomError page = section.Errors[code];
			
			    if (page != null)
				{
			        return page.Redirect;
				}
		    }
			return section.DefaultRedirect;
		}
		static protected bool RunIt(HttpContext context){
			CustomErrorsSection section = ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
			switch(section.Mode){
				case CustomErrorsMode.Off:
					return false;
				case CustomErrorsMode.On:
					return true;
				case CustomErrorsMode.RemoteOnly:
					return !(context.Request.UserHostAddress=="127.0.0.1");
				default:
					return true;
			}
		}
						
	}
