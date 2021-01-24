ValidateCallRailRequestFiler.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace My_API.ActionFilters
{
    public class ValidateCallRailRequestFilter: ActionFilterAttribute
    {
        //private readonly ILogger<ValidateCallRailRequestFilter> _logger;
        //public ValidateCallRailRequestFilter(ILogger<ValidateCallRailRequestFilter> logger)
        //{
        //    _logger = logger;
        //}
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //executing before action is called
            // this should only return one object since that is all an API allows. Also, it should send something else it will be a bad request
            var param = actionContext.ActionArguments.SingleOrDefault();
            if (param.Value == null)
            {
                //_logger.LogError("Object sent was null. Caught in ValidateCallRailRequestFilter class.");
                actionContext.Result = new BadRequestObjectResult("Object sent is null");
                return;
            }
            var context = actionContext.HttpContext;
            if (!IsValidRequest(context.Request))
            {
                actionContext.Result = new ForbidResult();
                return;
            }
            base.OnActionExecuting(actionContext);
        }
        private static bool IsValidRequest(HttpRequest request)
        {
            string json = GetRawBodyString(request.HttpContext);
            string token = "072e77e426f92738a72fe23c4d1953b4"; // this is the token that the API (Call Rail) would provide
            string signature = request.Headers["Signature"];
            
            // validation for comparing encoding to bytes and hashing to be the same
            //https://rextester.com/EBR67249
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] key = encoding.GetBytes(token);
            HMACSHA1 hmac = new HMACSHA1(key);
            byte[] bytes = hmac.ComputeHash(encoding.GetBytes(json));
            
            string result = System.Convert.ToBase64String(bytes);            
            return signature.Equals(result, StringComparison.OrdinalIgnoreCase);
        }
        public static string GetRawBodyString(HttpContext httpContext)
        {
            var body = "";
            if (httpContext.Request.ContentLength == null || !(httpContext.Request.ContentLength > 0) ||
                !httpContext.Request.Body.CanSeek) return body;
            httpContext.Request.EnableRewind();
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(httpContext.Request.Body, System.Text.Encoding.UTF8, true, 1024, true))
            {
                body = reader.ReadToEnd();
            }
            httpContext.Request.Body.Position = 0;
            return body;
        }
    }
}
This includes a body reader that reads in the JSON and a way to deny incoming requests that don't match the signature as 403 forbidden.
Then within my controller:
[ValidateCallRailRequestFilter]
[HttpPost]
public async Task<ActionResult> PostAsync(dynamic request)
{
    ...
    return Ok();
}
with a `using My_Api.ActionFilters;`
And then I hit it with postman.
[![note that it is not "beautified"][1]][1]
[![note the header here][2]][2]
  [1]: https://i.stack.imgur.com/5Yrdf.png
  [2]: https://i.stack.imgur.com/yU0wi.png
