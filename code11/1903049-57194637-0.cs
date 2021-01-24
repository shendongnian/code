cs
public void Save(IList<IFormFile> UploadFiles)
        {
            long size = 0;
            try
            {
                foreach (var file in UploadFiles)
                {
                    var filename = ContentDispositionHeaderValue
                                        .Parse(file.ContentDisposition)
                                        .FileName
                                        .Trim('"');
                    filename = hostingEnv.ContentRootPath.Replace("WebApplication6.Server", "WebApplication6.Client") + $@"\{filename}";
                    size += (int)file.Length;
                    if (!System.IO.File.Exists(filename))
                    {
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
                Response.Headers.Add("custom-header", "Syncfusion");
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Syncfusion Upload";
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
**[index.razor]**
razor
@using Newtonsoft.Json;
@using Newtonsoft.Json.Converters;
<EjsUploader Id="UploadFiles" AutoUpload="true" Success="@OnSuccess">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove"></UploaderAsyncSettings>
</EjsUploader>
<p>Additional Header Text is: @HeaderData</p>
<p>Additional Response Data is: @ResponseData</p>
@code{
public string HeaderData;
public string ResponseData;
public void OnSuccess(object args)
{
    SuccessEventArgs eventArgs = JsonConvert.DeserializeObject<SuccessEventArgs>(args.ToString());
    HeaderData = eventArgs.Response.Headers;
    ResponseData = eventArgs.Response.StatusText;
    this.StateHasChanged();
}
//Success event args class.
public class SuccessEventArgs
{
    public object E { get; set; }
    public FileInfo File { get; set; }
    public string StatusText { get; set; }
    public string Name { get; set; }
    public string Operation { get; set; }
    public ResponseEventArgs Response { get; set; }
}
public class ResponseEventArgs
{
    public string Headers { get; set; }
    public object ReadyState { get; set; }
    public object StatusCode { get; set; }
    public string StatusText { get; set; }
    public bool withCredentials { get; set; }
}
}
And, you need to enable the allow header option in the Startup.cs file as mentioned in the below code example.
  public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
        }
We have prepared the sample and attached below.
**Sample Link:** 
https://www.syncfusion.com/downloads/support/directtrac/242743/ze/WebApplication6_additional_data-460323506  
Also, currently we are working on to provide the specific type for success event arguments and this support will be included in our patch release scheduled on mid of August 2019. We appreciate your patience until then. 
   
You can track the status of the issue from the below feedback link. 
**Link:** https://www.syncfusion.com/feedback/7647/need-to-provide-specific-type-for-success-event-arguments-in-the-uploader  
Regards,
Berly B.C
