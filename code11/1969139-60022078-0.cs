using System.Text.Json.Serialization; // System.Text.Json
using Newtonsoft.Json;                // Json.NET
namespace Assignment_1
{
    public class MyRequest
    {
//...
        [JsonProperty(                                         // JsonProperty from Newtonsoft
			"changeTypes", 
			ItemConverterType = typeof(JsonStringEnumConverter)// JsonStringEnumConverter from System.Text.Json
		)]
        public AppGlobals.BoardSymbols[] GameBoard { get; set; }
    }
}
So as you can see, you are mixing up attributes from Newtonsoft with converters from `System.Text.Json`, which isn't going to work.  (Perhaps you selected the namespaces from a "Resolve -> using ..." right-click in Visual Studio?)
So, how to resolve the problem?  Since Json.NET supports renaming of enum values out of the box, the easiest way to resolve your problem is to use this serializer.  While possibly not as performant as `System.Text.Json` it is much more complete and full-featured.
To do this, **remove** the namespaces `System.Text.Json.Serialization` and `System.Text.Json` and references to the type `JsonStringEnumConverter` from your code, and modify `MyRequest` and `BoardSymbols` as follows:
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
namespace Assignment_1
{
    public class MyRequest
    {
//...
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        [JsonProperty("changeTypes")] // No need to add StringEnumConverter here since it's already applied to the enum itself
        public AppGlobals.BoardSymbols[] GameBoard { get; set; }
    }
}
namespace AppGlobals
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BoardSymbols
    {
        [EnumMember(Value = "X")]
        First = 'X',
        [EnumMember(Value = "O")]
        Second = 'O',
        [EnumMember(Value = "?")]
        EMPTY = '?'
    }
}
Then NuGet [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) and in `Startup.ConfigureServices` call `AddNewtonsoftJson()`:
services.AddMvc()
    .AddNewtonsoftJson();
Or if you prefer to use `StringEnumConverter` globally:
services.AddMvc()
    .AddNewtonsoftJson(o => o.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()));
Do take note of the following comment from the [docs](https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-3.1&tabs=visual-studio#newtonsoftjson-jsonnet-support)
 > **Note:** If the `AddNewtonsoftJson` method isn't available, make sure that you installed the [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson) package. A common error is to install the [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) package instead of the [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson) package.
Mockup fiddle [here](https://dotnetfiddle.net/87QmpO).
