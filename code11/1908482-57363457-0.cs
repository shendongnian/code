    var weekIds = Enumerable.Range(0, 4); // assuming your weeks are 0, 1, 2, 3
    var tes2 = joinnya
        .Where(i => i.idKategori == itemktgr.id)
        .Where(a => a.month == bln)
        .Where(o => o.year == dateNya.Year)
    var countPerWeek = weeks.GroupJoin(
        tes2,
        week => week,
        row => row.week,
        (week, weekGroup) => weekGroup.Count()
    );
