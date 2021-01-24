    int Compare(string a, string b)
    {
        var aV = a.Split('.');
        var bV = b.Split('.');
        if (aV.Length != bV.Length)
            return aV.Length.CompareTo(bV.Length);
        for(var i = 0; i < aV.Length; i++)
        {
            var comparisonResult = Int32.Parse(aV[i]).CompareTo(Int32.Parse(bV[i]));
            if (comparisonResult != 0)
                return comparisonResult;
        }
        return 0;
                
    }
    var list = new[] { "1.5.47","4.5","5.6","6.6" };
    var comparer = Comparer<string>.Create(Compare);
    var result = list.OrderBy(i => i, comparer).ToList();
