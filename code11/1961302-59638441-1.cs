    public class MyCsv : IReturn<string> {}
    public async Task Any(MyCsv request)
    {
        var file = base.VirtualFileSources.GetFile("path/to/my.csv");
        if (file == null)
            throw HttpError.NotFound("no csv here");
        Response.ContentType = MimeTypes.Csv;
        Response.AddHeader(HttpHeaders.ContentDisposition, 
            $"attachment; filename=\"{file.Name}\";");
        using (var stream = file.OpenRead())
        {
            await stream.CopyToAsync(Response.OutputStream);
            await Response.OutputStream.FlushAsync();
            Response.EndRequest(skipHeaders:true);
        }
    }        
