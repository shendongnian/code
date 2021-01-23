    @if( !Model.Any() )
    {
        <tr><td colspan="4">There are no Frames</td></tr>
    }
    else
    {
        foreach (var item in Model)
        {
            <tr>
                <td>
                    @Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) |
                    @Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) |
                    @Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })
                </td>
                <td>
                    @item.PictureID
                </td>
                <td>
                    @item.UserID
                </td>
                <td>
                    Meta 1: @item.MetaTagsObj.Meta1 Meta 2: @item.MetaTagsObj.Meta2 Meta 3: @item.MetaTagsObj.Meta3
                </td>
            </tr>
        }
    }
