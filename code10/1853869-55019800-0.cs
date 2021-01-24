    public class YourPageModel : PageModel
    {
        public string ErrorMessage { get; set; }
    
        public void OnGet() // or OnPost, whichever
        {
            try
            {
                var internet = "nc -w 5 -z 8.8.8.8 53  >/dev/null 2>&1 && echo 'ok' || echo 'error'".Bash();
            }
            catch (Exception ex2)
            {
                _logger.LogError(0, ex2, "An exception was thrown attempting " +
                                "to execute the error handler.");
                ErrorMessage = "Error in command try again";
            }
        }
    }
