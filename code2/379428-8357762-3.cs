    public class ChildActionController : Controller
        {
            public ActionResult Index(string Color)
            {
                SenderModel sender = new SenderModel { Title = "Sender", Color = "red" };
                if (!string.IsNullOrEmpty(Color))
                {
                    sender.Color = Color;
                }
                return View(sender);
            }
    }
