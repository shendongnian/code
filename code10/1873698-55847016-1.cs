C#
[HttpGet("CreateFile")]
public IActionResult CreateFile(string word)
{
    word = "test";
    byte[] b = Encoding.ASCII.GetBytes(word);
    string base64 = System.Convert.ToBase64String(b);
    b = Encoding.ASCII.GetBytes(base64);
    var txtStream = new MemoryStream(b);
    return File(txtStream, "text/plain", "license.dat");
}
