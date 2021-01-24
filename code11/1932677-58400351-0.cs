    private readonly UnitOfMeatures _referenceUnits = UnitOfMeasures.Meter;
    // Multiply the input values by these to get to the reference units.
    // Divide the reference values by these to get to the output units.
    private const double COEFFICIENT_METER = 1.0f; 
    private const double COEFFICIENT_KILOMETER = 1000.0f;    
    private const double COEFFICIENT_FOOT = 0.3048f;    
    private const double COEFFICIENT_INCH = 0.0254f;         // use Google to find these.
    
    // Create map of UnitOfMeasures to coefficients
    private Dictionary<UnitOfMeasures, double> _coefficientMap = new Dictionary<UnitOfMeasures, double>() {
        {UnitOfMeasures.Meter, COEFFICIENT_METER}, {UnitOfMeasure.Kilometer, COEFFICIENT_KILOMETER} // etc...
    };
    
    public double ConvertUnits(UnitOfMeasures inputUnits, double value, UnitOfMeasures outputUnits) {
        double result = 0.0f;
        
        // convert to reference units
        result = value * _coefficientMap[inputUnits];
    
        // convert to output units
        result = result / _coefficientMap[outputUnits];
    
        return result;
    }
