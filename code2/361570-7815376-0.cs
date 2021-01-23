    public class HorseViewModel
    {
        [Required(ErrorMessage = "Please give the horse a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a gender.")]
        public int SelectedGenderId { get; set; }
        public ICollection<Gender> Genders { get; set; }
    }
