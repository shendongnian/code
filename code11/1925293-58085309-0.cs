    public class CountryViewModel
    {
        public IEnumerable<Country> CountryList { get; set; }
        public int CountryID;
        public DateTime? TimeForCheckedOut {get;set;}
    }
    @model PenaltyCalculation.Models.ViewModel.CountryViewModel
    
    <form class="" style="margin-top:10%;" action="/" method="post">
        <div class="form-group">
            <label>Check out date of the Book</label>
            <input class="form-control" type="date" name="TimeForCheckedOut">
        </div>
        <div class="form-group">
            <label>Choose a country</label>
            @Html.DropDownListFor(m=>m.CountryId,new SelectList(Model.CountryList,"countryId","countryName"),new {@class="form-control" })
        </div>
        <button type="submit" class="btn btn-primary">Calculate</button>
    </form>
    [HttpPost]
    public ActionResult Index(CountryViewModel cvModel)
    {
        return View();
    }
