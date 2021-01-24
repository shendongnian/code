    public class SignupModel : PageModel
    {
        [BindProperty]
        public SignupPageModel Input { get; set; }
    
        public void OnGet()
        {
            Input = new SignupPageModel();
            Input.Hobbies = _repo.GetHobbiesCheckBoxGroup();
        }
    }
