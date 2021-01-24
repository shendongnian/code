    public interface IElements<TElement>
    	where TElement : ElementA
    {
    	List<TElement> Elements { get; set; }
    }
