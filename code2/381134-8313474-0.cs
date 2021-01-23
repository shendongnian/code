    public partial class ReportingService
    
    {
    
      
    
     protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            WebRequest request = base.GetWebRequest(uri);
    
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, CultureInfo.CurrentCulture.Name);
    
            return request;
        }
    
    }
