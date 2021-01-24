[HttpGet]
public ActionResult ListofLBFronendIPConfig(string resourceGroupName, string loadBalancerName)
{
    // . . . 
}
Then you need to change your return statements with the action method to use the provided View Result helper methods found on the MVC Controller class.  For Example:
[HttpGet]
public ActionResult ListofLBFronendIPConfig( string resourceGroupName, string loadBalancerName )
{
    try
    {
        var token = HttpContext.Session.GetString( "Token" );
        var tenantid = HttpContext.Session.GetString( "TenantId" );
        var sessionId = HttpContext.Session.GetString( "SessionId" );
        if ( !string.IsNullOrEmpty( token ) || !string.IsNullOrEmpty( tenantid ) )
        {
            var path = $"/api/PaasCatalog/GetLBFrontendIPConfigList?resourceGroupName=" + resourceGroupName + "&loadBalancerName=" + loadBalancerName;
            var response = _httpClient.SendRequestWithBearerTokenAsync( HttpMethod.Get, path, null, token, tenantid, _cancellationToken, sessionId ).Result;
            if ( !response.IsSuccessStatusCode )
                return new HttpStatusCodeResult(response.StatusCode);  //return a status code result that is not 200. I'm guessing on the property name for status code.
            var result = response.Content.ReadAsStringAsync().Result;
            if ( result == null )
                return View();  // this one could be lots of things... you could return a 404 (return new HttpNotFoundResult("what wasn't found")) or you could return a staus code for a Bad Request (400), or you could throw and exception.  I chose to return the view with no model object bound to it.
            var jsontemplates = JsonConvert.DeserializeObject<List<Project.Entity.ViewModels.PassCatalog.LBFrontendIPConfig>>( result );
            return View(jsontemplates);
        }
        else
        {
            // retrun the redirect result...don't just call it
            return RedirectToAction( "SignOut", "Session" );
        }
    }
    catch ( Exception ex )
    {
        _errorLogger.LogMessage( LogLevelInfo.Error, ex );
        // rethrow the exception (or throw something else, or return a status code of 500)
        throw;
    }
}
I changed all of your return statements.  You would need a cshtml view named ListofLBFronendIPConfig.cshtml that knows how to make use of the json object you bound to it's model.  Hope this helps.
