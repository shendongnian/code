    public interface IImageService
    {
    	string GetImagePath(string imageName);
    }
    
    public class ImageService : IImageService
    {
    	private readonly string _baseUrl;
    
    	public ImageService(IConfiguration configuration)
    	{
    		_baseUrl = configuration?.GetValue<string>("ImagesBaseUrl") ?? throw new ArgumentNullException(nameof(configuration));
    	}
    
        // probably improve this further with / checking, handle extensions, etc
    	public string GetImagePath(string imageName)
    	{
    		return string.Concat(_baseUrl, imageName);
    	}
    }
