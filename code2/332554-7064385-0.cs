    <div style="width:300px;height:250px;overflow:auto;">
    @foreach (var a in (IEnumerable<SelectListItem>)ViewBag.AllDecisionReasons)
    {
        @Html.CheckBox("DecisionReasons", a.Selected, new { value = a.Value })
    
        <label>@a.Text</label><br />
    }
    @Html.ValidationMessage("DecisionReasons", (string)Model.DecisionReasons)
