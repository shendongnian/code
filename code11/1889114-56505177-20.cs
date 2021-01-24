    public static class  Extension
    {
        public static List<Category> UpdateSequence(this List<Category> categories, int oldValue,int newValue)
        {
    		var invalidState = -1;
    		if(oldValue>newValue)
    		{
    			categories.Single(x=>x.sequence == oldValue).sequence = invalidState;
    		}
    		
    		if(categories.Any(x=>x.sequence == newValue))
            {
                categories = UpdateSequence(categories, newValue,newValue+1);
            }
    		if(oldValue<newValue)
    		{
    			categories.Single(x=>x.sequence==oldValue).sequence = newValue;
    		}
    		if(oldValue>newValue)
    		{
    			categories.Single(x=>x.sequence == invalidState).sequence = newValue;
    		}
            return categories;
        }
    }
