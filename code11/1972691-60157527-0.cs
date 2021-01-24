<!-- -->
    public class UtilityController : ControllerBase
    {
        [HttpPost]
        public IActionResult SwitchTheme([FromForm] bool isDark, string returnUrl)
        {
            // switch the theme
            // redirect back to where it came from
            return RedirectToLocal(returnUrl);
        }
    }
