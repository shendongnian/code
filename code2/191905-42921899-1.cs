    public class Immutable<T> {
    	public T Val { get; private set; }
    	public Immutable(T t) {
    		Val = t;
    	}
    }
