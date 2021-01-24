csharp
public class RemoveContentTypeAttribute : ResultFilterAttribute {
    public MediaTypeCollection ContentTypes { get; } = new MediaTypeCollection();
    public RemoveContentTypeAttribute(string contentType, params string[] otherContentTypes) {
        ContentTypes.Add(contentType);
        foreach (var currentContentType in otherContentTypes) {
            ContentTypes.Add(currentContentType);
        }
    }
    public override void OnResultExecuted(ResultExecutedContext context) {
        var result = (ObjectResult)context.Result;
        foreach (var contentType in ContentTypes) {
            result.ContentTypes.Remove(contentType);
        }
    }
}
**Controller**
csharp
[RemoveContentType("application/json", "application/vnd.api+json")]
public async Task<IActionResult> Update(string id, [FromBody]JsonPatchDocument<Value> patchDocument)
{ ... }
