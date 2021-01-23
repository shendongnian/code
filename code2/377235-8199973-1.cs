using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
 
public class InjectedFilterAttribute : ActionFilterAttribute {
 
    [Dependency]
    public IMathService MathService { get; set; }
 
    public override void OnResultExecuted(ResultExecutedContext filterContext) {
        filterContext.HttpContext.Response.Write(
            String.Format("<p>The filter says 2 + 3 is {0}.</p>",
                          MathService.Add(2, 3))
        );
    }
}
