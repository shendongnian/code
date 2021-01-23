    @model MySite.QuestionViewModel
    @using System.Linq;
    @using System.Collections;
    
    @{
        ViewBag.Title = "Question";
        Layout = "~/Views/Shared/Layout.cshtml";
    }
    <h2>Question</h2>
    
    @using (Html.BeginForm(new { id = "FormQuestion" }))
    {
    
        foreach (var prop in ViewData.ModelMetadata.Properties
            .Where(pm => pm.ShowForDisplay && !ViewData.TemplateInfo.Visited(pm) && ViewData.Model.EnabledField(pm)))
        {
            if (prop.HideSurroundingHtml)
            {
                Html.Editor(prop.PropertyName);
            }
            else
            {
                <div class="editor-label">
                    @(prop.IsRequired ? "*" : "")
                    @Html.Label(prop.PropertyName)
                </div>
                <div class="editor-field">
                    @Html.Editor(prop.PropertyName, prop.Model)
                    @Html.ValidationMessage(prop.PropertyName, "*")
                </div>
            }
        }
    }
