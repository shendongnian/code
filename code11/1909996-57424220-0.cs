    public class InputModel
    {
    	// actual image
    	public byte[] ProfilePic { get; set; }
    
    	// image to pass to POST method (so to update)
    	public IFormFile ProfilePicToUpdate { get; set; }
    }
