    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Web;
    
    // http://support.microsoft.com/kb/308000
    // http://www.c-sharpcorner.com/UploadFile/hemantkathuria/ASPNetHttpModules11262005004251AM/ASPNetHttpModules.aspx
    // http://www.15seconds.com/issue/020417.htm
    // http://www.worldofasp.net/tut/prjaspxmod/ASPNET_HTTP_Modules_168.aspx
    // http://dotnetslackers.com/articles/aspnet/ErrorLoggingModulesAndHandlers.aspx
    // http://www.stardeveloper.com/articles/display.html?article=2009071801&page=1
    // http://www.devx.com/dotnet/Article/6962/1954
    // http://www.west-wind.com/weblog/posts/59731.aspx
    public class IPbanning : IHttpModule
    {
    	private static System.Collections.Specialized.StringCollection m_scIPadresses = FillBlockedIps();
    	public void Dispose()
    	{
    	}
    	public void Init(System.Web.HttpApplication context)
    	{
    		context.BeginRequest += new EventHandler(context_BeginRequest);
    		//AddHandler context.EndRequest, New EventHandler(AddressOf IHttpModule_Dispose)
    	}
    	/// <summary>
    	/// Checks the requesting IP address in the collection
    	/// and block the response if it's on the list.
    	/// </summary>
    
    	private void context_BeginRequest(object sender, EventArgs e)
    	{
    		string strIP = HttpContext.Current.Request.UserHostAddress;
    
    		if (string.IsNullOrEmpty(strIP)) {
    			HttpContext.Current.Response.Write("<h1>Server-Error: IP is NULL</h1>");
    			HttpContext.Current.Response.End();
    			return;
    		}
    		if (strIP == "127.0.0.2") {
    			HttpContext.Current.Response.Write("<h1 style=\"color: blue;\"><font color=\"red\">YOU</font> (" + HttpContext.Current.Request.UserHostAddress.ToString() + ") are banned.</h1>");
    			//HttpContext.Current.Response.StatusCode = 403
    			HttpContext.Current.Response.End();
    		}
    		if ((m_scIPadresses.Contains(strIP))) {
    			HttpContext.Current.Response.StatusCode = 403;
    			HttpContext.Current.Response.End();
    		}
    	}
    	/// <summary>
    	/// Retrieves the IP addresses from the web.config
    	/// and adds them to a StringCollection.
    	/// </summary>
    	/// <returns>A StringCollection of IP addresses.</returns>
    	private static System.Collections.Specialized.StringCollection FillBlockedIps()
    	{
    		System.Collections.Specialized.StringCollection scIPcollection = new System.Collections.Specialized.StringCollection();
    		//Dim strRaw As String = ConfigurationManager.AppSettings.Get("blockip")
    		string strRaw = "44.0.234.122, 23.4.9.231";
    		strRaw = strRaw.Replace(",", ";");
    		strRaw = strRaw.Replace(" ", ";");
    
    		foreach (string strIP in strRaw.Split(";")) {
    			scIPcollection.Add(strIP.Trim());
    		}
    
    		return scIPcollection;
    	}
    }
