public IActionResult Redirect1()
{
    <strike>var r = RedirectToAction(nameof(GetStream));</strike>
    <strike>return r;                                   </strike>
    <b>var url = this.Url.Action(nameof(GetStream));    </b>
    return <b>Content(
        $"&lt;script&gt;history.pushState({{}},'downloading','{url}');history.go()&lt;/script&gt;",
        "text/html"
    );</b>
}
