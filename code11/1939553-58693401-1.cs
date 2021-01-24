    foreach (emp e in emps)
    {
        var item = list.FirstOrDefault(x => x.ID == e.empID && x.Salary > 5000);
        if (item != null)
        {
            item.Level = B;
            item.Hike = e.Hike;
            item.Salary = (e.Hike + 100) * e.Salary / 100;
        }
    }
