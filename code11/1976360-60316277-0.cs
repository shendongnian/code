@using Microsoft.AspNetCore.Http.Extensions;
String url = @Context.Request.GetDisplayUrl();
var uri = new Uri(url);
String url_project = uri.Segments[2].Replace(@"/", "");
Note that I use this code in view.
