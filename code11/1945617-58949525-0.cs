<strike>[Serializable]</strike>
public class FileProvider
{
    public string TestString { get; set; }
    <strike>public IFormCollection FormData { get; set; }</strike>
    <b>public IList&lt;IFormFile&gt; Files { get; set; }</b>
}
public IActionResult Upload(<b>[FromForm]</b>FileProvider fileProvider)
{
    var files = fileProvider.Files;
    var testString = fileProvider.TestString;
    ...
}
