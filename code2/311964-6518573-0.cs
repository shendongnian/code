    public class EditProductViewModel {
    	[HiddenInput]
    	public int Id {get;set;}
    	[Required]
    	public string Name {get;set;}
    	[Required]
    	public string Description {get;set;}
    	public HttpPostedFileBase Image {get;set;}
    }
