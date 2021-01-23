    @model bool?           
    @{
        if (ViewData.ModelMetadata.IsNullableValueType) {
       <text><div class="RB"></text>
        Dictionary<string, object> yesAttrs = new Dictionary<string, object>(); 
        Dictionary<string, object> noAttrs = new Dictionary<string, object>(); 
        Dictionary<string, object> nullAttrs = new Dictionary<string, object>(); 
    
        yesAttrs.Add("id", ViewData.TemplateInfo.GetFullHtmlFieldId("") + "Yes");
        noAttrs.Add("id", ViewData.TemplateInfo.GetFullHtmlFieldId("") + "No");
        nullAttrs.Add("id", ViewData.TemplateInfo.GetFullHtmlFieldId("") + "n/a");
    
        
        if (Model.HasValue && Model.Value)
        {
            yesAttrs.Add("checked", "checked");
        }
        else if (Model.HasValue && !Model.Value)
        {
            noAttrs.Add("checked", "checked");
        }
        else
        {
            nullAttrs.Add("checked", "checked");
        } 
    
    
        @Html.RadioButtonFor(x => x, "true", yesAttrs) <label for="@(ViewData.TemplateInfo.GetFullHtmlFieldId(""))Yes">Yes</label>
        @Html.RadioButtonFor(x => x, "false", noAttrs) <label for="@(ViewData.TemplateInfo.GetFullHtmlFieldId(""))No">No</label>
        @Html.RadioButtonFor(x => x, "", nullAttrs) <label for="@(ViewData.TemplateInfo.GetFullHtmlFieldId(""))NA" class="nostrong" title="Unknown or To Be Determined">tbd</label>
    @:</div>
        }
        else {
            ModelState state = ViewData.ModelState[ViewData.ModelMetadata.PropertyName];
                    bool value = Model ?? false;
            if (state != null && state.Errors.Count > 0) {
                <div class="input-validation-error" style="float: left"></div>
        }else{
                @Html.CheckBox("", value)
        }
        }
    }
