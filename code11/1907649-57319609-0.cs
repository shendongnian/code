    var group = yourLoadedCollectionOfExcelRows.GroupBy(x => x.Department)
    .OrderByDesc(x => x.TotalScore).ToList()
    .ForEach(x => {
       Console.WriteLine(x.Key);
       foreach (string item in x.Take(5)) {
         Console.WriteLine(item.empno);
         Console.WriteLine(item.dept);
         Console.WriteLine(item.scoretotal);
       }
    });
