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
**Update**
I was able to get the correct signature with the following code:
csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;
namespace netcoretest.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }
        // POST: /test
        [HttpPost]
        public async Task<ActionResult> PostTest([FromBody]string request)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] key = encoding.GetBytes("072e77e426f92738a72fe23c4d1953b4");
            HMACSHA1 hmac = new HMACSHA1(key);
            Byte[] bytes = hmac.ComputeHash(encoding.GetBytes(request));
            Console.WriteLine(ByteArrayToString(bytes));
            String result = System.Convert.ToBase64String(bytes);
            Console.WriteLine(result);
            return Ok();
        }
        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-","");
        }
    }
}
I tested posting to this endpoint using the following:
url --request POST https://localhost:5001/test --insecure --header 'Content-Type: application/json' --data-binary @test.json
where `test.json` is the sample JSON blob from the API Documentation.
If using this same code you cannot get the signature to match, double check that your `test.json` does not have any trailing newlines or whitespace.
Hope this helps!
