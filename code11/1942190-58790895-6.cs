    public class SubscriptionController : Controller
    {
        [AllowAnonymous]
        public ActionResult Subscribe()
        {
            var viewModel = new SubscriptionViewModel
            {
                Subscription = GetSubscription()
            };
            return View(viewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Subscribe(SubscriptionViewModel model, string date)
        {
            model.Subscription = GetSubscription();
            return View();
        }
        private Subscription GetSubscription()
        {
            return new Subscription
            {
                Id = 1,
                Name = "My Subscription"
            };
        }
    }
