    public class ValidateThing<TSource>
    {
    	public void AddValidation<TProperty>(Expression<Func<TSource, TProperty>> expr)
    	{
    		//...
    	}
    }
    
    public static class Tester
    {
    	public static void Test()
    	{
    		ValidateThing<string> v = new ValidateThing<string>();
    
    		v.AddValidation(s => s.Length);
    	}
    }
