    @foreach (var genderGroup in Model.GroupBy(t => t.Gender))
    {
        <ul>@genderGroup.Key
            <ul>
                <li><h2>By Category</h2></li>
                @foreach (var categoryGroup in genderGroup.GroupBy(t => t.Category))
                {
                    <li>@Html.ActionLink(categoryGroup.Key.Name,
                            genderGroup.Key, "Store",
                            new { Category = categoryGroup.Key.ID }, null)</li>
                }
            </ul>
            <ul>
                <li><h2>By Type</h2></li>
                @foreach (var typeGroup in genderGroup.GroupBy(t => t.Type))
                {
                    <li>@Html.ActionLink(typeGroup.Key.Name,
                            genderGroup.Key, "Store",
                            new { Type = typeGroup.Key }, null)</li>
                }
            </ul>
        </ul>
    }
