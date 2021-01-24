csharp
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.Formatters;
namespace netcoretest {
    public class RawJsonBodyInputFormatter : InputFormatter
    {
        public RawJsonBodyInputFormatter()
        {
            this.SupportedMediaTypes.Add("application/json");
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                return await InputFormatterResult.SuccessAsync(content);
            }
        }
        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }
    }
}
in **Startup.cs:**
csharp
// in ConfigureServices()
services.AddMvc(options => {
    options.InputFormatters.Insert(0, new RawJsonBodyInputFormatter());
});
In your controller:
[HttpPost]
public async Task<ActionResult> PostTest([FromBody]string request)
{
  // here request is now the request body as a plain string;
  // you can now compute the signature on it and then later parse it to JSON.
}
However, testing your current code to generate the Base64-encoded signature, I am not getting the correct signature:
1. you are converting the output of the HMAC to hexadecimal string, and then taking the bytes of that string and putting those into your Base64 encoding.  The sample ruby you linked returns plain bytes, not a hexadecimal string from `HMAC.digest`:
ruby
[5] pry(main)> hmac = OpenSSL::HMAC.digest(OpenSSL::Digest.new('sha1'), YOUR_COMPANY_SIGNING_KEY, s)
=> "Q\x90\amG_\x9Bq\xAA/\xBA\xB3\x8AQ\xA8\xCCl\xD6W\xAE"
So at least that portion needs to be corrected in your implementation as well.
