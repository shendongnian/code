    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class FileStreamingService : IFileStreamingV1
    {
    	Stream IFileStreamingV1.GetFileStream(string downloadFileLocation)
    	{
    		if (!File.Exists(downloadFileLocation))
    		{
    			throw new FaultException("The file could not be found");
    		}
    
    		FileStream stream = File.OpenRead(downloadFileLocation);
    		return stream;
    	}
    }
