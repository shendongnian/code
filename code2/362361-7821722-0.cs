    public interface IArray<T>
    {
    	int Length { get; }
    
    	T this[int index] { get; }
    }
    
    internal sealed class ImmutableArray<T> : IArray<T>
    	where T : struct
    {
    	private readonly T[] _wrappedArray;
    
    	internal ImmutableArray(IEnumerable<T> data)
    	{
    		this._wrappedArray = data.ToArray();
    	}
    
    	public int Length
    	{
    		get { return this._wrappedArray.Length; }
    	}
    
    	public T this[int index]
    	{
    		get { return this._wrappedArray[index]; }
    	}
    }
    
    public class InputObject
    {
    	private readonly IArray<double> _x;
    	private readonly IArray<double> _y;
    
    	public InputObject(double[] x, double[] y)
    	{
    		this._x = new ImmutableArray<double>(x);
    		this._y = new ImmutableArray<double>(y);
    	}
    
    	public IArray<double> X
    	{
    		get { return this._x; }
    	}
    
    	public IArray<double> Y
    	{
    		get { return this._y; }
    	}
    
    	//...
    }
