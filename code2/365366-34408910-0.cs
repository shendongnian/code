    public class SharedController : Controller
        {
            // GET: /<controller>/
            public IActionResult _Layout(string btnLogout)
            {
                if (btnLogout != null)
                {
                    return LocalRedirect("~/Index");
                }
    
                return View();
            }
    }
