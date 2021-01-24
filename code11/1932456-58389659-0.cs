public IActionResult Safe1([Bind(nameof(UserModel.Name))] UserModel model)
{
    return View("Index", model);
}
> 2. Use [Editable] or [BindNever] on the model
public class UserModel
{
    [MaxLength(200)]
    [Display(Name = "Full name")]
    [Required]
    public string Name { get; set; }
    [Editable(false)]
    public bool IsAdmin { get; set; }
}
> 3. Use two different models
public class BindingModel
{
    [MaxLength(200)]
    [Display(Name = "Full name")]
    [Required]
    public string Name { get; set; }
}
public class UserModel
{
    [MaxLength(200)]
    [Display(Name = "Full name")]
    [Required]
    public string Name { get; set; }
    [Editable(false)]
    public bool IsAdmin { get; set; }
}
> 4. Use a base class
public class BindingModel
{
    [MaxLength(200)]
    [Display(Name = "Full name")]
    [Required]
    public string Name { get; set; }
}
public class UserModel : BindingModel
{
    public bool IsAdmin { get; set; }
}
> 5. Use ModelMetadataTypeAttribute
[ModelMetadataType(typeof(UserModel))]
public class BindingModel
{
    public string Name { get; set; }
}
public class UserModel
{
    [MaxLength(200)]
    [Display(Name = "Full name")]
    [Required]
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
}
