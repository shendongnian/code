    using System.Web.Services;
    .......
    [WebMethod()]
    public static string GetPreviousFileName()
    {
        //put logic here to get the filename to compare against.
        return "somefilename.ext";
    }
