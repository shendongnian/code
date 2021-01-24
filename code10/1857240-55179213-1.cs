public class MyStaticFileOptions : StaticFileOptions { }
public class StaticFileDetector{
    private StaticFileOptions _sfo;
    public StaticFileDetector(IOptions<MyStaticFileOptions> sfo)
    {
        this._sfo = sfo.Value;
    }
    public bool FileExists(PathString path){
        // you might custom it as you like
        var baseUrl = this._sfo.RequestPath;
        // get the relative path
        PathString relativePath = null;
        if(!path.StartsWithSegments(baseUrl, out relativePath))
        {
            return false;
        }
        var file = this._sfo.FileProvider.GetFileInfo(relativePath.Value);
        return !file.IsDirectory && file.Exists;
    }
}
and then register them as services :
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.Configure<MyStaticFileOptions>(o => {
        o.FileProvider = new PhysicalFileProvider("C:\\TEMP");
        o.RequestPath = PathString.FromUriComponent("/sub1/sub2");
    });
    services.AddSingleton<StaticFileDetector>()
}
Finally, suppose you want to detect whether a request path will be processed :
    app.Use(async(ctx,next) => {
        var path = ctx.Request.Path;
        var detector = app.ApplicationServices.GetService<StaticFileDetector>();
        var exists = detector.FileExists(path);
        // now you know whether current request path exists or not. 
        await next();
    });
    app.UseStaticFiles();
    app.UseStaticFiles(app.ApplicationServices.GetService<IOptions<MyStaticFileOptions>>().Value);
    // ...
Or if you would like to detect some path within a Controller, simply inject this service as below :
    public class HomeController : Controller
    {
        private StaticFileDetector _dector;
        public HomeController(StaticFileDetector dector)
        {
            this._dector = dector;
        }
        public IActionResult Index()
        {
            var path = new PathString("some-path-here");
            var x = this._dector.FileExists(path);
            return Json(x);
        }
    }
**[Edit]** : Avoid using `File.Exists(unsafe_path_string)` directly, it not safe if you pass an unsafe path string.
