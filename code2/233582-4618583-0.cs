    private static List<double> GetGreater(List<double> first, List<double> second)
    {
        int firstCounter = 0;
        int secondCounter = 0;
    
        for (int i = 0; i < first.Count; i++)
        {
            if (first.ElementAt(i) > second.ElementAt(i))
            {
                firstCounter++;
            }
            else if (first.ElementAt(i) < second.ElementAt(i))
            {
                secondCounter++;
            }
        }
    
        // return the greater list instead of bool
        return (firstCounter > secondCounter ? first : second);
    }
    
    
    public static List<double> Greater(params List<double>[] p)
    {
        // assumes the first list is the greater, then check the others
        // this method assumes you will always pass at least 2 lists
        List<double> greater = p[0];
        
        for (var i = 1; i < p.Length; ++i)
        {
            greater = GetGreater(greater, p[i]);
        }
    
        return greater;
    }
    static void Main(string[] args)
    {
        // lists used for this test
        var l1 = new List<double>() { 1, 222, 3 };
        var l2 = new List<double>() { 1, 2, 4 };
        var l3 = new List<double>() { 11, 222, 333 };
    
        var l4 = Greater(l1, l2, l3); // l3
    }
