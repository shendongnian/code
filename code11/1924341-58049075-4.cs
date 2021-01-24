    // initiate a new Unit instance. 
    var unit = new Unit(UnitType.Week);
    
    // Get values
    var name = unit.Name;
    var symbol = unit.Symbol;
    var factor = unit.Factor;
    
    // In case if some units doesn't have base
    if (unit.Base != null)
    {
    	var baseName = unit.Base.Name;
    	var baseSymbol = unit.Base.Symbol;
    	var baseFactor = unit.Base.Factor;
    
    }
