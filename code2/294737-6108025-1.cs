    public class TempFileProvider : IDisposable
    {
    	public Filename { get; private set; }
    
    	public TempFileProvider()
    	{
    		Filename = Path.GetTempFileName();
    	}
    
    	public void Dispose()
    	{   
    		File.Delete(Filename);
    	}
    }
