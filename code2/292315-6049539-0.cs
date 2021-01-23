    public class ItemParent {  // formerly Base1
	    public List<ItemChild> MyChildren {get; set;}
	}
	
    public class ItemChild {  // formerly Base2
	    public ItemParent MyParent {get; set;}
	}
    public class Car : ItemParent {  // formerly Sub1
	    public List<CarPart> MyParts {get; set;}
	}
	
    public class CarPart : ItemChild {  // formerly Sub2
	    public Car ParentCar {get; set;}
	}
