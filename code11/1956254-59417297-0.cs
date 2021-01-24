lang-cs
// PageModel
public IActionResult OnPost(string user, string pass)
{
    if (Database.Auth(user, pass))
    {
        Response.Redirect("Index");
    }
    ViewData["InvalidLogin"] = "alert-validate";
    return Page();
}
// Razor Page
<div class="wrap-input100 validate-input @ViewData["InvalidLogin"]" data-validate="Check Username">
On initial load, this will not apply any extra class. It will only add the extra class if the validation fails and you send the page back to the browser.
I realized halfway through this you're using Razor Pages, so apologies if anything here is more MVC focused.
