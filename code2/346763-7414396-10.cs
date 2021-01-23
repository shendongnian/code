       string ImageRepositoryName{get;set;}
   }    
    public interface IImageRetrievalConfiguration    
    {
         IImageRetrievalData GetConfig();
    }
    public class MockImageRetrievalConfiguration : IImageRetrievalConfiguration    
    {    
    	public IImageRetrievalData GetConfig()
         {
             //mock implementation
         }
    }
    
    public class ImageRetrievalConfiguration : IImageRetrievalConfiguration    
    {
    
    	public IImageRetrievalData GetConfig()
         {
            //Concrete implementation
         }
    }
    
 
    //your code
    ...
    IImageRetrievalConfiguration imageRetrievalConfig = (IImageRetrievalConfiguration)SpringApplicationContext.ApplicationContext["ImageRetrievalConfiguration"];
    
    return Uri.TryCreate(new Uri(imageRetrievalConfig.GetConfig().ImageRepositoryName), latestImage.FileName, out fullUrl) ? fullUrl.AbsoluteUri : ImageRetrievalConfiguration.MiniDefaultImageFullUrl;  
