    @model AppName.Models.CourseTableViewModel
    <td>
        @Html.CheckBoxFor(
            x => x.OwnerPremission, 
            new { 
                @disabled = "disabled",
                id = HtmlHelper.GenerateIdFromName("OwnerPremission." + ViewData.TemplateInfo.GetFullHtmlFieldName(""))
            }
        )
    </td>
