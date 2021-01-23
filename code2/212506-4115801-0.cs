    public class HomeController: Controller
    {
        public ViewResult Menu() {
            var viewModel = new ViewModel();
            viewModel.MenuLinks = _repository.GetMenuLinks();
            return PartialView("MenuPartial", viewModel);
        }
    } 
