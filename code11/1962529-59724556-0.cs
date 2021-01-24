lang-cs
using (var stream = new MemoryStream())
{
    var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
    context.Request.InputStream.Seek(0, SeekOrigin.Begin);
    context.Request.InputStream.CopyTo(stream);
    string requestBody = Encoding.UTF8.GetString(stream.ToArray());
}
**Applicable to my code, I used it in this way:**
lang-cs
public async Task<IHttpActionResult> UpdatePackageAsync(PackageUpdate request)
{
     string requestBody = ReadInputStream();
     // do stuff with request
}
private string ReadInputStream()
{
      using (var stream = new MemoryStream())
      {
           var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
           context.Request.InputStream.Seek(0, SeekOrigin.Begin);
           context.Request.InputStream.CopyTo(stream);
           return Encoding.UTF8.GetString(stream.ToArray());
      }
}
