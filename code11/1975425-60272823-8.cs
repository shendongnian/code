    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class StatusModel : PageModel
    {
        public string PageTitle { get;  set; }
        public string StatusNumber { get;  set; }
        public string StatusName { get;  set; }
        public string StatusDescription { get;  set; }
        public void OnGet(string? code = null)
        {
            if (null == code)
                code = HttpContext.Response.StatusCode.ToString();
            PageTitle = $"HTTP status {code}";
            StatusNumber = code;
            if (code.CompareTo("404") == 0)
            {
                StatusName = "Not found";
                StatusDescription = "The requested page was not found.";
            }
            else
            {
                StatusName = "Unknown error";
                StatusDescription = "An unknown error occurred.";
            }
        }
    }
