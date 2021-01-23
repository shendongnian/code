    public static class BoxEx
    {
    	public static IEnumerable<Box> Flatten(this Box box)
    	{
    		yield return box;
    		if (box.Contents != null)
    		{
    			foreach (var b in box.Contents.SelectMany(b2 => Flatten(b2)))
    			{
    				yield return b;
    			}
    		}
    	}
    }
