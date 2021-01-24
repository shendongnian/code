    var Totals = new Dictionary<int, int>();
    foreach (var student in StudentList)
    {
        var id = student.Id;
        if (!Totals.ContainsKey(id))
        {
            Totals[id] = 0;
        }
        Totals[id] += student.Mark;
    }
