    public static List<Point> FilterPoints(List<Point> master, List<Point> subset)
    {    
        return master.Where(p => !subset.Contains(p)).ToList();    
        // or even terser and faster (see below): 
        // return master.Except(subset).ToList();  
    }
