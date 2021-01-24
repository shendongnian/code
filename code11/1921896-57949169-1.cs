    class Shape
    {
    	public virtual double Area { get;}
    }
    
    class Circle : Shape
    {
    	public string Colour { get; set; }
    	public double Radius { get; set; }
    	public override double Area
    	{
    		get { return Radius * Radius * Math.PI; }
    	}
    }
