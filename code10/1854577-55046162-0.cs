    @{
        var weights = new List<SelectListItem>();
        foreach (var item in ViewBag.PossibleWeights)
        {
            weights.Add(
            new SelectListItem
            {
                Text = item,
                Value = item,
                Selected = item == Model.WeightCode
            });
        }
    }
    @Html.DropDownListFor(model => model.WeightCode, weights, new { @class = "form-control")
