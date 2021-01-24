[Authorize(Policy="Choice: policy='New York'| role= ADMIN")]
public IActionResult Privacy()
{
    return View();
}
