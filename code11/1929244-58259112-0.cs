    public class SignupModel : PageModel
    {
        [BindProperty]
        public SignupPageModel Input { get; set; }
    
        public void OnGet()
        {
            var model = new SignupPageModel();
            model.Hobbies = _repo.GetHobbiesCheckBoxGroup();
        }
    }
