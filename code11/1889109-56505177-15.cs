    public static class  Extension
    {
    	public static List<Category> UpdateSequence(this List<Category> categories, int oldValue,int newValue)
    	{
    		if(categories.Any(x=>x.sequence == newValue))
    		{
    			categories = UpdateSequence(categories,newValue,newValue+1);
    		}
    		categories.Single(x=>x.sequence==oldValue).sequence = newValue;
    		return categories;
    	}
    }
