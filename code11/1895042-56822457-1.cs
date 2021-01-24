void context_BeginRequest(object sender, EventArgs e)
{
    var app = (HttpApplication)sender;
    var encodings = app.Request.Headers.Get("Accept-Encoding");
    if (encodings == null)
        return;
    var baseStream = app.Response.Filter;
    // check if browser accepts gzip or deflate
    if (encodings.ToLower().Contains("gzip"))
    {
        app.Response.Filter = new GZipStream(baseStream, CompressionMode.Compress);
        app.Response.AppendHeader("Content-Encoding", "gzip");
        app.Context.Trace.Warn("GZIP compression on");
    }
    else if (encodings.ToLower().Contains("deflate"))
    {
        app.Response.Filter = new DeflateStream(baseStream, CompressionMode.Compress);
        app.Response.AppendHeader("Content-Encoding", "deflate");
        app.Context.Trace.Warn("Deflate compression on");
    }
}
I recommend using a library called `HttpCompress`, you can access it [here][1]. And again as other people said why don't you use built-in IIS compression module?
  [1]: https://github.com/blowery/HttpCompress
