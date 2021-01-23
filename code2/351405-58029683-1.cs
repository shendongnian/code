    private static long MatlabDateConversionFactor = (10000000L * 3600L * 24L);
    private static long tickDiference = 367;
    
    public static double convertToMATLABDateNum(DateTime dt) {
    	var converted = ((double)dt.Ticks / (double)MatlabDateConversionFactor);
    	return converted + tickDiference;
    }
    
    public static DateTime convertFromMATLABDateNum(double datenum) {
    	var ticks = (long)((datenum - 367) * MatlabDateConversionFactor);
    	return new DateTime(ticks, DateTimeKind.Utc);
    }
            
