    var models = ObjectsModel();
        var grouped = models.GroupBy(s => s.ObjectsModel.Name)
        .Select(x => x.Select(y => y))
        .ToList();
        return View(grouped);
    
        @for(int i = 0; i < Model.Count; i++)
        {
         <h2>@Html.DisplayFor(model => model[i].First().ObjectsModel.Name)</h2>
        <ul>
            for(int j = 0; j < Model[i].Count; j++)
            {
            <li>@Html.DisplayFor(model => model[i][j].Object)</li>
            }
        </ul>
        }
