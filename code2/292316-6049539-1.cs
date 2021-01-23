    public class ItemParent<T> where T : ItemChild {
	    public List<T> MyChildren {get; set;}
	}
	
    public class ItemChild<T> where T : ItemParent {
	    public T MyParent {get; set;}
	}
	
    public class Car : ItemParent<CarPart> {}
    public class CarPart : ItemChild<Car> {}
    public class Truck : ItemParent<TruckPart> {}
    public class TruckPart : ItemChild<Truck> {}
