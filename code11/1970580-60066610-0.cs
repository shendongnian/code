public class MyClass
{
    public int flagInt { get; set; }
    
    [JsonIgnore]
    public bool flag
    {
        get
        {
            switch (flagInt)
            {
                case 0: return false;
                case 1: return true;
                default: throw new Exception("Cannot convert flag to bool");
            }
        }
    }
}
Note that I don't have a setter on `flag` so doing something like `flag = false` will not have expected results and will not serialize correctly either.
