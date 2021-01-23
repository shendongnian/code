    public struct ValueIndexPair<T>
    {
    	private readonly T mValue;
    	private readonly int mIndex;
    
    	public T Value { get { return mValue; } }
    	public int Index { get { return mIndex; } }
    	
    	public override string ToString()
    	{
    		return "(" + Value + "," + Index + ")";
    	}
    	
    	public ValueIndexPair(T value, int index)
    	{
    		mValue = value;
    		mIndex = index;
    	}
    }
    
    public static IEnumerable<ValueIndexPair<T>> WithIndex<T>(this IEnumerable<T> sequence)
    {
    	int i = 0;
    	foreach(T value in sequence)
    	{
    		yield return new ValueIndexPair<T>(value, i);
    		i++;
    	}
    }
