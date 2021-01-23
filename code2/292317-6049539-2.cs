    public class ParentChildCollection<TParent, TChild> {}
    public class Car {
	    private ParentChildCollection<Car, CarPart> PartHierarchy;
		public List<CarPart> MyParts {get { return PartHierarchy.GetMyChildren(this); } }
    }
    public class CarPart {
	    private ParentChildCollection<Car, CarPart> PartHierarcy;
		public Car ParentCar {get { return PartHierarchy.GetMyParent(this); }}
    }
