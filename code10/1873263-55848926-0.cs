    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace UploadAzureBlob.Services
    {
    	public interface IBlobManager
    	{
    		Task<string> UploadFileToBlobAsync(string fileName, Stream fileStream);
    	}
    }
