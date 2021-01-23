    private void SeeOther(Uri uri)
    {
      if(!uri.IsAbsoluteUri)
        uri = new Uri(Request.Url, uri);
      Response.StatusCode = 303;
      Response.AddHeader("Location", uri.AbsoluteUri);
      Response.ContentType = "text/uri-list";
      Response.Write(uri.AbsoluteUri);
      Context.ApplicationInstance.CompleteRequest();
    }
    private void SeeOther(string relUri)
    {
      SeeOther(new Uri(Request.Url, relUri));
    }
