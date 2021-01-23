    public class MyModel
    {
   
	    [Editor(typeof(FullscreenCollectionEditor), typeof(UITypeEditor))]
	    public List<FileModel> Files { get; set; }
    }
