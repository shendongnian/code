    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            var model = new CountryViewModel()
            {
                CountryList = GetCountries()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CountryViewModel model)
        {
            model.CountryList = GetCountries();
            return View(model);
        }
        private IEnumerable<Country> GetCountries()
        {
            return new Country[]
                {
                    new Country()
                    {
                        CountryID = 1,
                        CountryName = "USA"
                    },
                    new Country()
                    {
                        CountryID = 2,
                        CountryName = "Mexico"
                    },
                };
        }
    }
    public class CountryViewModel
    {
        public IEnumerable<Country> CountryList { get; set; }
        public int CountryID { get; set; }
        public DateTime? TimeForCheckedOut { get; set; }
    }
    public partial class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
    <form class="" style="margin-top:10%;" action="/Country/Index" method="post">
        <div class="form-group">
            <label>Check out date of the Book</label>
            <input class="form-control" type="date" name="TimeForCheckedOut">
        </div>
        <div class="form-group">
            <label>Choose a country</label>
            @Html.DropDownListFor(m => m.CountryID, new SelectList(Model.CountryList, "CountryID", "CountryName"), new { @class = "form-control" })        
        </div>
        <button type="submit" class="btn btn-primary">Calculate</button>
    </form>
