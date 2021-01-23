    public class GenericClass<T>
    	where T : A
    	where T : B
    	where T : C
    {
    	public T MyMember { get; set; }
    
    	public GenericClass(T myMember)
    	{
    		this.MyMember = myMember;
    	}
    }
