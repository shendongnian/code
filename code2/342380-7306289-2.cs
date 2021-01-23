    // our product class
    public sealed class Product {
    	public int id {get;private set;}
    	public string name {get; private set;}
	
        public Product(int id, string name)
        {                 
            this.id=id;
            this.name=name;
        }
    }
