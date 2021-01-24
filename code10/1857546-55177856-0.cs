    public void RemoveNonSoldCars(DomainObject parent)
    {
    	parent.Cars.RemoveAll(x => !x.Sold);
    	foreach (var item in parent.Children)
    		RemoveNonSoldCars(item);
    }
