    @foreach (var item in Model)
    {
        <li>@item.Gender
            <ul>
                <li><h2>By Category</h2></li>
                @foreach (var category in item.Categories)
                {
                    <li>@Html.ActionLink(category.Name,
                            "ByCategory", "Store",
                            new {
                                Gender = item.Gender,
                                Category = category.ID,
                            }, null)</li>
                }
            </ul>
            <ul>
                <li><h2>By Type</h2></li>
                @foreach (var type in item.Types)
                {
                    <li>@Html.ActionLink(type.Name,
                            "ByType", "Store",
                            new {
                                Gender = item.Gender,
                                Type = type.ID,
                            }, null)</li>
                }
            </ul>
        </li>
    }
