[AllowAnonymous]
public IActionResult AccessDenied()
{
    <strike>return this.View("/Pages/Error");</strike>
    <b>return new RedirectToPageResult("/Error", "GET", null);</b>
}
