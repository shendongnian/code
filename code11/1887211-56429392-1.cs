    public class ContainerA : IElements<ElementA>
    {
    	public List<ElementA> Elements { get; set; }
    }
    
    public class ContainerB : IElements<ElementB>
    {
    	public List<ElementB> Elements { get; set; }
    }
