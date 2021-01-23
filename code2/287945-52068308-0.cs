    public class FooViewModel
    {
       [Required(ErrorMessage = "Name is required")]
       [Display(Name ="Name*")]
       public string Name { get; set; }
    }
    Html.LabelFor(o => o.Name)
