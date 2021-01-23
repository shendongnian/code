    var columnList = new[] {"ColB"};
    var res = myList.Select(d => Project(d, columnList));
    ...
    static ExpandoObject Project(MyDataObject d, string[] columns) {
        var res = new ExpandoObject();
        // Using reflection here is a much better solution
        if (Array.IndexOf(columns, "ColA") >= 0) res.ColA = d.ColA;
        if (Array.IndexOf(columns, "ColB") >= 0) res.ColB = d.ColB;
        if (Array.IndexOf(columns, "ColC") >= 0) res.ColC = d.ColC;
        return res;
    }
