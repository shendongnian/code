    		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Common.CheckDatabaseConnection())
			{
				this.LiteralMachineName.Text = Environment.MachineName;	
			}
			else
			{
				Response.ClearHeaders();
				Response.ClearContent(); 
				Response.Status = "503 ServiceUnavailable";
				Response.StatusCode = 503;
				Response.StatusDescription= "An error has occurred";
				Response.Flush();
				throw new HttpException(503,string.Format("An internal error occurred in the Application on {0}",Environment.MachineName));  
			}
		}
