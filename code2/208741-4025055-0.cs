    public class NavigationController
    {
        [ChildActionOnly]
        public ViewResult Menu(string currentAction, string currentController)
        {
            var navigationViewModel = new NavigationViewModel();
    
            // delegates the actual highlighing to your view model
            navigationViewModel.Highlight(currentAction, currentController);
    
            return View(navigationViewModel);
        }
    }
