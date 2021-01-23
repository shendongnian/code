    public class Payee
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    
    	public Payee() { }
    	public Payee(int id, string name)
    	{
    		ID = id;
    		Name = name;
    	}
    }
