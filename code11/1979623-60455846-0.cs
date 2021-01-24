[HttpGet]
[Authorize]
public IActionResult Contacts()
{
    var model = new Contact();
    var contacts = new Contact[] { model };
    return View(contacts);
}
