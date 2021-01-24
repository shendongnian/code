    @using (Html.BeginForm("ParentReturn", "Home", FormMethod.Post))
    {
        for (int i = 0; i < Model.ClassOfTradeList.Count; i++)
        {
            @Html.CheckBoxFor(model => Model.ClassOfTradeList[i].IsSelected);
            @Html.HiddenFor(model => Model.ClassOfTradeList[i].Name);
            @Html.LabelFor(model => Model.ClassOfTradeList[i].IsSelected, Model.ClassOfTradeList[i].Name);
            <br />
        }
        <input type="submit" value="click" />
    }
