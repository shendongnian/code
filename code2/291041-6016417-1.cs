    @using ErasProject.Models
    @model ErasProject.Models.Bulletin1ViewModel
    <script src="jquery.min.js"></script>
    <script src="jQuery.Validate.min.js"></script>
    <script src="jquery.validate.unobtrusive.min.js"></script>
    @using (Html.BeginForm())
    { 
        @Html.ValidationSummary(true)
        <fieldset>
        <p>
        @Html.EditorFor(model => model.NumberDelegations)
        @Html.ValidationMessageFor(model => model.NumberDelegations)
        </p>
        <p>
        @Html.EditorFor(model => model.TravelPlans)
        @Html.ValidationMessageFor(model => model.TravelPlans)
        </p>
        <p>
        <input type="submit" value="Submit" />
        </p>
        </fieldset>
    }
