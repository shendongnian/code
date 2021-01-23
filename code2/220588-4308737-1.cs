    MyDataContext dbm = new MyDataContext();
    var groups = dbm.SubCategories
              .Select(x=> new { CatName = x.Category.Name, x.SubCategoryName });
              .GroupBy(x=>x.CatName);
    resultSpan.InnerHtml += "<table>";
    foreach (var group in groups)
    {
        resultSpan.InnerHtml += "<tr><td>" + group.Key + "</td></tr>";
        foreach (var s in group)
        {
            resultSpan.InnerHtml += "<tr><td>&nbsp;&nbsp;&nbsp;" + s.SubCategoryName + "</td></td>";
        }
    }
    resultSpan.InnerHtml += "</table>";
