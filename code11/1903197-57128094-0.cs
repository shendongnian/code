    public abstract class Vehicle
    {
    	private readonly double _baseFuelConsumption;
    	
    	protected double BaseFuelConsumption => _baseFuelConsumption;
    	
    	protected Vehicle(double baseFuelConsumption) => _baseFuelConsumption = baseFuelConsumption;
    	
    	public virtual double ActualFuelConsumption => BaseFuelConsumption;
    }
