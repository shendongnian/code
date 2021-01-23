    public class MyController : Controller {
        public JsonResult MethodName(Guid key){
            var result = ApiHelper.GetData(key);
            return new EscapedJsonResult(result);
        }
    }
    public class EscapedJsonResult<T> : JsonResult {
        public EscapedJsonResult(T data) {
            this.Data = data;
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }
        public override ExecuteResult(ControllerContext context) {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            var output = new StreamWriter(response.OutputStream);
            // TODO: Do some reflection magic to go through all properties
            // of the this.Data property and write JSON to the output stream
            // using the StreamWriter
            // You need to handle arrays, objects, possibly dictionaries, numbers,
            // booleans, dates and strings, and possibly some other stuff... All
            // by your self!
        }
        // Finds non-ascii and double quotes
        private static Regex nonAsciiCodepoints =
            new Regex(@"[""]|[^\x20-\x7f]");
        // Call this for encoding string values
        private static string encodeStringValue(string value) {
            return nonAsciiCodepoints.Replace(value, encodeSingleChar);
        }
        // Encodes a single character - gets called by Regex.Replace
        private static string encodeSingleChar(Match match) {
            return "\\u" + char.ConvertToUtf32(match.Value, 0).ToString("x4");
        }
    }
