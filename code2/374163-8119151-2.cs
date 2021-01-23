    @foreach (var genderGroup in Model.GroupBy(t => t.Gender))
    {
        <ul>@genderGroup.Key
            <ul>
                <li><h2>By Category</h2></li>
                @foreach (var categoryGroup in genderGroup.GroupBy(t => t.Category))
                {
                    <li>@Html.ActionLink(categoryGroup.Key.Name,
                            "ByCategory", "Store",
                            new {
                                Gender = genderGroup.Key,
                                Category = categoryGroup.Key.ID
                            }, null)</li>
                }
            </ul>
            <ul>
                <li><h2>By Type</h2></li>
                @foreach (var typeGroup in genderGroup.GroupBy(t => t.Type))
                {
                    <li>@Html.ActionLink(typeGroup.Key.Name,
                            "ByType", "Store",
                            new {
                                Gender = genderGroup.Key,
                                Type = typeGroup.Key
                            }, null)</li>
                }
            </ul>
        </ul>
    }
