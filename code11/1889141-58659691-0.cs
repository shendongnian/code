    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    public class RenderingService : IRenderingService
    {
            
    	private readonly IHostingEnvironment _hostingEnvironment;
    	public RenderingService(IHostingEnvironment hostingEnvironment)
    	{
    	_hostingEnvironment = hostingEnvironment;
    	}
    
    	public string RelativeAssemblyDirectory()
    	{
    		var contentRootPath = _hostingEnvironment.ContentRootPath;
    		string executingAssemblyDirectoryAbsolutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    		string executingAssemblyDirectoryRelativePath = System.IO.Path.GetRelativePath(contentRootPath, executingAssemblyDirectoryAbsolutePath);
    		return executingAssemblyDirectoryRelativePath;
    	}
    }
