    double[] tabHeight = { 16, 10, 15, 20 };
    double[] tabMidSectionWA = { 6, 2, 5, 6 };
    
    double[] tabCurveWA = Enumerable.Range(0, Math.Min(tabHeight.Length, tabMidSectionWA.Length))
                                    .Select(i => (tabHeight[i] - tabMidSectionWA[i]) / 2)
                                    .ToArray();
    		
    Console.WriteLine(string.Join(", ", tabCurveWA)); // outputs 5, 4, 5, 7
