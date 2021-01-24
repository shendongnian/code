    public enum VehicleMake
    {
    	Acura,
    	Audi,
    	BMW,
    	Chevrolet,
    	Dodge,
    	Fait,
    	Ford,
    	Hyundai,
    	Honda,
    	Nissan,
    	Toyota
    }
    
    public enum FuelType
    {
    	Gas,
    	Diesel
    }
    
    public interface IVehicle
    {
    	FuelType Fuel { get; }
    
    	VehicleMake Make { get; set; }
    
    	string Model { get; set; }
    
    	int MakeYear { get; set; }
    
    	IRental Rental { get; set; }
    }
    
    public interface IRental
    {
    	bool IsRented { get; set; }
    }
    
    public class Rental : IRental
    {
    	public bool IsRented { get; set; }
    }
    
    public class Car : IVehicle
    {
    	public FuelType Fuel => FuelType.Gas;
    
    	public VehicleMake Make { get; set; }
    
    	public string Model { get; set; }
    
    	public int MakeYear { get; set; }
    
    	public IRental Rental { get; set; }
    
    }
    
    public class Truck : IVehicle
    {
    	public FuelType Fuel => FuelType.Diesel;
    
    	public VehicleMake Make { get; set; }
    
    	public string Model { get; set; }
    
    	public int MakeYear { get; set; }
    
    	public IRental Rental { get; set; }
    
    }
