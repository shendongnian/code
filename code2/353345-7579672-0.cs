    public enum Test { A, B, C };
    
    public interface IParent1 { string method1(Test @enum);}
    
    public class Parent1 : IParent1
    {
    	public string method1(Test @enum)
    	{
    		return @enum.ToString();
    	}
    }
