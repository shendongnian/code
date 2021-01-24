    public partial class Movie
    {
    	public Movie()
    	{
    			
    	}
    	
    	public Movie(string genre, string title)
    	{
    		Genre = genre;
    		Title = title;
    	}
    	
    	public string Genre { get; set; }
    	public string Title { get; set; }
    }
