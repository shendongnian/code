    public class Model
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Description { get; set; }
    }
    
    public class Manufacturer
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Description { get; set; }
    	public List<Model> Models { get; set; }
    }
