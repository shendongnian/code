 lang-c#
using CspReportLogger.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace CspReportLogger.Formatters
{
  public class CSPReportInputFormatter : TextInputFormatter
  {
    public CSPReportInputFormatter()
    {
	  // Specify the custom media type.
      SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/csp-report"));
      SupportedEncodings.Add(Encoding.UTF8);
    }
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding effectiveEncoding)
    {
	  // Deserialize the body using our models and the JsonSerializer.
      CspReportRequest report = await JsonSerializer.DeserializeAsync<CspReportRequest>(context.HttpContext.Request.Body);
      return await InputFormatterResult.SuccessAsync(report);
    }
  }
}
Which has to be registered in Startup.cs of course:
 lang-c#
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers(options =>
      {
        options.InputFormatters.Insert(0, new CSPReportInputFormatter());
      });
    }
I wish I had seen [Kirk Larkin's solution](https://stackoverflow.com/a/59813295/12730491) earlier, as it obviously is more concise.
I suppose the custom formatter solution is helpful, if you want to accept body types that aren't valid json though.
