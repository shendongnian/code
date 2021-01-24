    public class Car : Vehicle
    {
    	private const double _ACModifier = 0.9;
    	
    	public Car()
    	:base(1)
    	{		
    	}
    	
    	public bool IsACOn { get; set; }
    
    	public override double ActualFuelConsumption
    	{
    		get
    		{
    			double consumption = base.ActualFuelConsumption;
    			consumption += IsACOn ? _ACModifier : 0;
    			return consumption;
    		}
    	}
    }
