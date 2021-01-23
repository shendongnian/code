    @model IEnumerable<AppName.Models.Reminders>
    @using (Html.BeginForm())
    {
        @Html.EditorForModel()
        <input type="submit" value="OK" />
    }
