    public class SqlConnection : object {}    
    public class Random : object {}
    
    public SqlConnection GetA() { return new SqlConnection(); }
    public Random GetB() { return new Random(); }
    
    void Main()
    {   
        var p = GetA() ?? GetB();
    }
