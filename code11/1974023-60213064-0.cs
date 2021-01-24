public class YourPageModel : PageModel
{
    public IBfvEncryption _bfvEncryption { get; set; }
    public YourPageModel(IBfvEncryption bfvEncryption)
    {
        _bfvEncryption = bfvEncryption;
    }
    public class InputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Address { get; set; }
        // ... etc.
    }
    public void OnPostTest()
    {
        //Ensure the Data has been Correctly Entered into the form.
        if (!ModelState.IsValid)
        {
            error = "The Data was not In the correct form,Please try again.";
            
            // _bfvEncryption is available to you here now.
            // return Page();
        }
        
        error = "Is this working";
        //return RedirectToPage("/Index", new { city = InputModel.Address });
    }
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
