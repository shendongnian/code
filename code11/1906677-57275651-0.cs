    public main()
    {
        List<ColorPoint> colorList = new List<ColorPoint>(4);
        AdaptMeshPoints(colorList, x => x.color.ToString());
    }
    public List<T> AdaptMeshPoints<T>(List<T> pointList, Func<T, string> whatToPrint)
        where T : Point
    {
        pointList[0].x = 45;
        Console.WriteLine(whatToPrint(pointList[0]));
    }
