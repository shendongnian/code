    using ExpressiveAnnotations.Attributes;//reference at the top
    public class EnrollmentModel : BaseModel
    {
        ...
        public bool PriceOption { get; set; }
        [Required(ErrorMessage = "Please select a rate plan")]
        public string SelectedRatePlan { get; set; }
        public IEnumerable<SelectListItem> RatePlans { get; set; }
        [RequiredIf("PriceOption == true")]
        public string CustomRate { get; set; }
        ...
        }
    }
