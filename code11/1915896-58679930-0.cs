	public class ReflectionDynamicObject : DynamicObject {
		public JsonElement RealObject { get; set; }
		public override bool TryGetMember (GetMemberBinder binder, out object result) {
			// Get the property value
			var srcData = RealObject.GetProperty (binder.Name);
			result = null;
			switch (srcData.ValueKind) {
				case JsonValueKind.Null:
					result = null;
					break;
				case JsonValueKind.Number:
					result = srcData.GetDouble ();
					break;
				case JsonValueKind.False:
					result = false;
					break;
				case JsonValueKind.True:
					result = true;
					break;
				case JsonValueKind.Undefined:
					result = null;
					break;
				case JsonValueKind.String:
					result = srcData.GetString ();
					break;
				case JsonValueKind.Object:
					result = new ReflectionDynamicObject {
						RealObject = srcData
					};
					break;
				case JsonValueKind.Array:
					result = srcData.EnumerateArray ()
						.Select (o => new ReflectionDynamicObject { RealObject = o })
						.ToArray ();
					break;
			}
			//Try to convert depending on specific cast
			if (binder.ReturnType == typeof (DateTime) && result is string) {
				result = DateTime.Parse ((string) result);
			}
			if (binder.ReturnType == typeof (DateTime?)) {
				if (!string.IsNullOrEmpty ((string) result)) {
					result = DateTime.Parse ((string) result);
				}
			}
			if ((binder.ReturnType == typeof (int) ||
					binder.ReturnType == typeof (int?)) &&
				result != null) {
				result = srcData.GetInt32 ();
			}
			if ((binder.ReturnType == typeof (long) ||
					binder.ReturnType == typeof (long?)) &&
				result != null) {
				result = srcData.GetInt64 ();
			}
			// Always return true; other exceptions may have already been thrown if needed
			return true;
		}
	}
and this is an example usage, to parse the request body - one part is in a base class for all my WebAPI controllers, that exposes the body as a dynamic object:
    [ApiController]
    public class WebControllerBase : Controller {
        // Other stuff - omitted
        protected async Task<dynamic> JsonBody () {
            var result = await JsonDocument.ParseAsync (Request.Body);
            return new ReflectionDynamicObject {
                RealObject = result.RootElement
            };
        }
    }
and can be used in the actual controller like this:
//[...]
    [HttpPost ("")]
    public async Task<ActionResult> Post () {
        var body = await JsonBody ();
        var name = (string) body.Name;
        //[...]
    }
//[...]
If needed, you can integrate parsing for GUIDs or other specific data types as needed - while we all wait for some official / framework-sanctioned solution.
