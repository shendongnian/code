    public class Solution
    {
    	private List<Image> x { get; set; } // assuming you initialised this
    	private List<int> y { get; set; } // assuming you initialised this
    
    	public List<Image> GetImages(int start, int end)
    	{
    		return x.Zip(y, (x, y) => new Tuple<int, Image>(y, x)) // merging your two arrays into a list of Tuple<int, Image>
    		 .Where(i => i.Item1 >= start && i.Item1 <= end) // this is your BETWEEN clause
    		 .Select(i => i.Item2).ToList(); // returning images
    	}
    }
