    try
    {
    	SPWeb myWeb = SPContext.Current.Web;
    	SPFile newFile = myWeb.GetFile(myWeb.ServerRelativeUrl + "/SiteAssets/newFile.txt");
    }
    catch (Exception ex)
    {
    	Console.WriteLine(ex.Message);
    }
