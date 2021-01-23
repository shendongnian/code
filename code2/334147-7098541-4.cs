    @model EditorTemplate.Models.Gender // switch to your namespace
    @Html.LabelFor(x => x, "Male")
    @if(Model == EditorTemplate.Models.Gender.Male)
    {
        @Html.RadioButtonFor(x => x, (int)EditorTemplate.Models.Gender.Male, new { @checked = "checked" });
    }
    else
    {
        @Html.RadioButtonFor(x => x, (int)EditorTemplate.Models.Gender.Male);
    }
    @Html.LabelFor(x => x, "Female")
    @if(Model == EditorTemplate.Models.Gender.Female)
    {
        @Html.RadioButtonFor(x => x, (int)EditorTemplate.Models.Gender.Female, new { @checked = "checked" });
    }
    else
    {
        @Html.RadioButtonFor(x => x, (int)EditorTemplate.Models.Gender.Female);
    }
