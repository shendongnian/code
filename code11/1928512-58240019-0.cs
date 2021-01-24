    namespace WebApplicationSkip1.Controllers
    {
        public class CountryModel
        {
            [DisplayName("#")]
            public int StateID { get; set; }
            [DisplayName("Country")]
            public string Countryname { get; set; }
            [DisplayName("State")]
            public string StateName { get; set; }
        }
        public class StateDisplayModel // Index Listing
        {
            public List<CountryModel> CountryModel { get; set; }
            public string SelectedCountry { get; set; }
        }
        public class StateData
        {
            public StateDisplayModel stateDisplaytList()
            {
                CountryModel sdm1 = new CountryModel { Countryname = "USA", StateID = 1, StateName = "Arizona" };
                CountryModel sdm2 = new CountryModel { Countryname = "France", StateID = 2, StateName = "FranceCity" };
                CountryModel sdm3 = new CountryModel { Countryname = "Germany", StateID = 3, StateName = "GermanyCity" };
                StateDisplayModel sdm = new StateDisplayModel();
                sdm.CountryModel = new List<CountryModel>
                {
                    sdm1,
                    sdm2,
                    sdm3
                };
                return sdm;
            }
        }
        public class HomeController : Controller
        {
            [HttpPost]
            public ActionResult Index8(StateDisplayModel sdm)
            {
                //put a breakpoint here to see selected item
                var q = sdm.SelectedCountry;
                return View();
            }
            public ActionResult Index8(int? Id)
            {
                //initial id
                Id = 1;
                StateData statData = new StateData();
                StateDisplayModel cntry = statData.stateDisplaytList();
                //var cntry = stateList.Where(s => s.StateID == Id).FirstOrDefault();
                //get all instead
                return View(cntry);
            }
