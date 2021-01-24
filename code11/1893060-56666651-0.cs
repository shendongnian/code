csharp
class PagesController : Controller
{
    [HttpGet("about")]
    public IActionResult About() => View("MyCommonView", yourModel); // get the model from wherever you plan to
    [HttpGet("contact")]
    public IActionResult Contact() => View("MyCommonView", yourModel);
    [HttpGet("whateverelse")]
    public IActionResult WhateverElse() => View("MyCommonView", yourModel);
}
It's possible to just have one action, but I wouldn't do that. I'd instead have separate views per action, and put the markup that's common for the three actions layout file. That will give the different actions more flexibility.
