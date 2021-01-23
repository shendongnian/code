    @using System.Linq;
    @using System.Collections;
    
    @{
        ViewBag.Title = "Question";
        Layout = "~/Views/Shared/Layout.cshtml";
    }
    <h2>Question</h2>
    
    
    @using (Html.BeginForm(new { id = "FormQuestion" }))
    {
        foreach (var item in ViewData.ModelMetadata.Properties) 
        {
            if (ViewData.Model.EnabledField(item)) 
            { 
                <div>
                    <span>@item.PropertyName : </span>
                    @Html.TextBox(item.PropertyName)
                </div>
            }
        }
    }
