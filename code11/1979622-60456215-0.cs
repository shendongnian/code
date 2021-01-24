public class MyController : Controller 
{
    private IWebHostEnvironment _hostingEnvironment;
    public MyController(IWebHostEnvironment environment) {
        _hostingEnvironment = environment;
    }
    [HttpGet]
    public IActionResult Get() {
        
        var path = Path.Combine(_hostingEnvironment.WebRootPath, "GoogleDriveFiles");
        ...
    }
You can pass the root path to your class's constructor. After all, a class named `GoogleDriveFilesRepository` only cares about its local folder, not whether it's hosted on a web or console application. For that to work, the methods should *not* be static:
    public class GoogleDriveFilesRepository 
    {
        public GoogleDriveFilesRepository (string rootPath)
        {
            _rootPath=rootPath;
        }
        public DriveService GetService()
        {
             //Operations.... 
        public List<GoogleDriveFiles> GetDriveFiles()
        {
            // Other operations....
        }
    }
You can register that class as a service in Startup.cs :
public class Startup
{
    private readonly IWebHostEnvironment _env;
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddSignleton<GoogleDriveFilesRepository>(_ =>{
            var gdriveRoot=Path.Combine(_env.WebRootPath,"GoogleDriveFiles");
            return new GoogleDriveFilesRepository(gdrivePath);
        });
        ...
    }
}
This class can now be used as a dependency on a controller. It's no longer necessary to use `IWebHostEnvironment` in the controller :
public class MyController : Controller 
{
    private GoogleDriveFilesRepository _gdrive;
    public MyController(GoogleDriveFilesRepository gdrive) {
        _gdrive=gdrive;
    }
}
The nice thing with dependency injection is that if done right, the classes themselves don't need to know that DI is used. `MyContainer` and `GoogleDriveFilesRepository` can be used in eg a unit test without having to setup DI :
[Fact]
public void Just_A_Test()
{
    var repository=new GoogleDriveFilesRepository("sometestpath");
    var myController=new MyController(repository);
    myController.DoTheUpload(...);
}
