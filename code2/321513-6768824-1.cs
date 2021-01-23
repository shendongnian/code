    public class CompanyController : Controller
    {
        public ActionResult Details(int id)
        {
            CompanyRepository repo = new CompanyRepository();
            return View(repo.GetCompanyById(id));
        }
    }
