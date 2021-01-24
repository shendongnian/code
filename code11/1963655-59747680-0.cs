    namespace testproject
        [BindProperties]
        public class testModel : testModel
        {
       public int package  { get; set; } = 3;
       public List<SelectListItem> packagelist { get; set; }
       public int selectedpackage { get; set; }
     public void OnGet()
            {
                packagelist = new List<SelectListItem> {
            new SelectListItem { Value = "5", Text = "t1" },
            new SelectListItem { Value = "10", Text = "t2" },
            new SelectListItem { Value = "12", Text = "t3" },
        };
    }
