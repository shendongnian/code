return this.RedirectToAction( nameof(this.GetAll) );
However, `RedirectToAction` creates a HTTP 302 redirection which, strictly speaking, is incorrect as you should return HTTP 303 which means you need to do this:
public class SeeOtherRedirectResult : ActionResult
{
    private readonly string url;
 
    public PermanentRedirectResult(string url)
    {
        this.url = url;
    }
 
    public override void ExecuteResult(ControllerContext context)
    {
        context.HttpContext.Response.StatusCode       = 303;
        context.HttpContext.Response.RedirectLocation = this.url;
    }
}
// Inside your action:
return new SeeOtherRedirectResult( this.Urls.Action( nameof(this.GetAll) ) );
  [1]: https://en.wikipedia.org/wiki/Post/Redirect/Get
