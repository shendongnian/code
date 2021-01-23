    public class LayoutController : Controller
    {
        //
        // GET: /Layout/
        public PartialViewResult Menu()
        {
            var viewModel = new MenuViewModel {IsAdministrator = true};
            return PartialView(viewModel);
        }
    }
