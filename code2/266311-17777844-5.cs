    var us = new CultureInfo("en-US");
    var norwegian = new CultureInfo("nb-NO");
    
    Unit.Tablespoon == UnitSystem.Create(us).Parse("tbsp")
    Unit.Tablespoon == UnitSystem.Create(norwegian).Parse("ss")  
    
    "T" == UnitSystem.GetDefaultAbbreviation(Unit.Tablespoon, us)
    "ss" == UnitSystem.GetDefaultAbbreviation(Unit.Tablespoon, norwegian)
