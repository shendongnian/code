    public interface ITokenDefinition<out T>{}
    public class TokenDefinition<T> : ITokenDefinition<T> {  }
    
    void Main()
    {
    
    	var expected = new List<ITokenDefinition<object>>();
    	expected.Add(new TokenDefinition<string>());
    }
 
