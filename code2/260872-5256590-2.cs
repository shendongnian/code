    @model IEnumerable<AppName.Models.MyViewModel>
    @using (Html.BeginForm())
    {
        @Html.EditorForModel()
        <input type="submit" value="OK" />
    }
