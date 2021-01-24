    // initiate a new Unit instance. 
    var unit = new Unit(UnitType.Week);
    
    // Get values
    var type = unit.Type;
    var name = unit.Name.Long;
    var symbol = unit.Name.Short;
    var factor = unit.Factor;
    var baseName = unit.Base.Name.Long;
    var baseSymbol = unit.Base.Name.Short;
    var baseFactor = unit.Base.Factor;
