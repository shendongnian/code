    public class SettingsModel : PageModel
      {
    public class InputModel
        {
          public string NewKeywords { get; set; }
          public string PredefinedKeywords { get; set; }
        }
    [BindProperty]
        public InputModel Input { get; set; }
        public async Task OnGetAsync()
        {
          var predefinedKeywords = <GetListFromDatabaseOperation>;
          this.Input = new InputModel
          {
            PredefinedKeywords = $"{predefinedKeywords.GetListSeperatedByNewLineAsync()}|{predefinedKeywords.Count}",
          };
        }
