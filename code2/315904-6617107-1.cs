    @{
        if (Model != null)
        {
            int itemCount = 0;        
            <ul class="multi-list">
                @foreach (var item in Model) {
                    itemCount++;
                    <li>
                        @Html.DisplayFor(modelItem => item.Name)
                        @Html.CheckBoxFor(modelItem => item.Active)
                    </li>
                    if (Model.Count() > 10 && itemCount == (int)(Model.Count() / 2))
                    {
                        @Html.Raw("</ul><ul class=\"multi-list\">");
                    }
                }
            </ul>
            <div class="clear"></div>
        }
    }
