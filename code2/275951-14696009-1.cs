    [WebMethod]
		public static void StaticPageMethod(string pVal)
		{
			var webService = new GridViewService();
			webService.GridCheckChanged(pVal);
		}
