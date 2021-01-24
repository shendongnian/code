    @model ViewModel
    <div class="form-group">
        @Html.LabelFor(model => model.Season, htmlAttributes: new { @class = "control-label col-md-2" })
         <div class="col-md-10">
            @Html.DropDownListFor(model => model.SelectedSeason, Model.SeasonList, new { @class = "form-control" })
            @*@Html.EditorFor(model => model.Season, new { htmlAttributes = new { @class = "form-control" } })*@
            @Html.ValidationMessageFor(model => model.Season, "", new { @class = "text-danger" })
        </div>
    </div>
    public class ViewModel
    {
        public string SelectedSeason { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public SelectList SeasonList { get; set; }
        public ViewModel() 
        {
            Seasons = new List<Season>() 
            {
                { new Season("2018-2019") },
                { new Season("Debug") },
                { new Season("Info") },
                { new Season("Warning") },
                { new Season("Error") },
            };
            SeasonList = new SelectList(Seasons, "Value", "Value");
        }
    }
