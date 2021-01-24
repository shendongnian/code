C#
[HttpGet("CreateFile")]
public IActionResult CreateFile(string word)
{
    word = "test";
    byte[] b = Encoding.ASCII.GetBytes(word);
    var txtStream = new MemoryStream(b);
    return File(txtStream, "text/plain", "license.dat");
}
I am getting a file with "test" inside.
But you should better use 
public FileResult CreateFile(string word)
