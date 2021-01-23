    public class Frames
    {
    	IEnumerable<Coordinate> CoordinatesObj { get; set; }
    	
    	public class Coordinate
    	{
    		int Position { get; set; }
    		int Top { get; set; }
    		int Left { get; set; }
    		int Height { get; set; }
    		int Width { get; set; }
    	}
    }
