    @if (memberCategories.Any(i => i.Id == item.Id))
    {
        //IF MEMBER HAS ALREDY PICKED THAT CATEGORY SHOW THIS:
        @Html.CheckBoxFor(m => m.IsSelected, new { @checked = true }) @item.Name
    }
    else
    {
        @Html.CheckBoxFor(m => m.IsSelected, new { @checked = false }) @item.Name
    }
