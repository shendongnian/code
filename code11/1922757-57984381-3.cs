    public static List<Point> FilterPoints(List<Point> master, List<Point> subset)
    {
        var subsetAsHashSet = new HashSet<Point>();
        return master.Where(p => !subsetAsHashSet.Contains(p)).ToList();    
    }
