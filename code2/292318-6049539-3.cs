    public class Car {  // formerly Base1
	    public List<CarPart> MyParts {get; set;}
	}
	
    public class CarPart {  // formerly Base2
	    public Car MyParent {get; set;}
	}
	
    public class Truck : Car {  // formerly Sub1
	    public List<TruckPart> MyParts {get; set;}
	}
	
    public class TruckPart : CarPart {  // formerly Sub2
	    public Truck MyParent {get; set;}
	}
