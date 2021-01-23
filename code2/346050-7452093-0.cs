    public static class BuildManagerViewEngineFluentExtensions {
    	public static BuildManagerViewEngine ControllerViews(this BuildManagerViewEngine engine) {
    		return FilterViewLocations(engine, x => x.Contains("/Views/Shared/") == false);
    	}
    
    	public static BuildManagerViewEngine SharedViews(this BuildManagerViewEngine engine) {
    		return FilterViewLocations(engine, x => x.Contains("/Views/Shared/") == true);
    	}
    
    	private static BuildManagerViewEngine FilterViewLocations(BuildManagerViewEngine engine, Func<string, bool> whereClause) {
    		engine.ViewLocationFormats = engine.ViewLocationFormats.Where(whereClause).ToArray();
    		engine.PartialViewLocationFormats = engine.PartialViewLocationFormats.Where(whereClause).ToArray();
    		return engine;
    	}
    }
