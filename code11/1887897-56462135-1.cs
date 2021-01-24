    public Import ValidateUploadModel(Import Model)
    {
        // DO not allow future dates
        if (Model.CurrMoInfo.CurrMo > DateTime.Now)
        {
            ModelState.AddModelError("CurrMoInfo.CurrMo", "You cannot assign a future date.");
        }
        //Do not allow dates from the same month (we run the processing a month behind)
        if (Model.CurrMoInfo.CurrMo.Month == DateTime.Now.Month)
        {
            ModelState.AddModelError("CurrMoInfo.CurrMo", "You must process a previous month.");
        }
        //Ensure day is last day of a previous month
        if (Model.CurrMoInfo.CurrMo.Day != DateTime.DaysInMonth(Model.CurrMoInfo.CurrMo.Year, Model.CurrMoInfo.CurrMo.Month))
        {
            ModelState.AddModelError("CurrMoInfo.CurrMo", "You must enter the last day of the month.");
        }
        //Do not allow dates older than 12 months back
        if (Model.CurrMoInfo.CurrMo < DateTime.Now.AddMonths(-12))
        {
            ModelState.AddModelError("CurrMoInfo.CurrMo", "Date must not be older than a year.");
        }
        return Model;
    }
    <div class="card-body">
        @if (Model.StagingCount == 0)
        {
            <input asp-for="CurrMoInfo.CurrMo" type="date" required class="col-lg-12" />
        }
        else
        {
            <input asp-for="CurrMoInfo.CurrMo" type="date" disabled="disabled" required class="col-lg-12" />
        }
        <span asp-validation-for="CurrMoInfo.CurrMo" class="text-danger"></span>
    </div>
