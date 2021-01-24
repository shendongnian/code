c#
<%@ WebService Language="C#" CodeBehind="~/App_Code/WebService.cs" Class="WebService" %>
This file is just used to call the code, at *"~/App_Code/WebService.cs"*. So if you want to call it from **POST**, you should use
www.host.com/pathTo/projectRoot/WebService.asmx/functionName?Params=values
After opening *"~/App_Code/WebService.cs"*, you should see something like that:
c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
}
Here, you can customize your code to receive and process **POST** data.
You can't use `Request["param"]` here, but `HttpContext.Current.Request["param"];` is the best approach I've found.
  [1]: https://i.stack.imgur.com/wMVz8.png
  [2]: https://i.stack.imgur.com/bUEQF.png
