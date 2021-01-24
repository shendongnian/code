csharp
Controller.PhysicalFileResult PhysicalFile(string physicalPath, string contentType, bool enableRangeProcessing);
Modify your DMZ API to use `PhysicalFile` to return a file to get the best performance and stability. Like this:
csharp
    public IActionResult GetContent(int id)
    {
        var content = from m in db.messagestoimages
                      where m.Message == id
                      select m;
        if (content == null || content.Count() == 0)
        {
            return NotFound();
        }
        string fileName = content.First().ImageURL;
        string fullPath = AppDomain.CurrentDomain.BaseDirectory  + fileName;
        if (File.Exists(fullPath))
        {
            return PhysicalFile(fullPath, "image/jpeg", true);
        }
        return NotFound();
    }
And for your public API, I have tested with the following code:
csharp
using System;
using System.IO;
using System.Net.Http;
namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.google.com");
                var response = client.GetAsync("/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png");
                var stream = response.Result.Content.ReadAsStreamAsync().Result;
                using (var mstream = new MemoryStream())
                {
                    stream.CopyTo(mstream);
                    File.WriteAllBytes("a.png", mstream.ToArray());
                }
            }
        }
    }
}
Which works fine and successfully downloaded the file which also can be opened successfully.
I guess it was not the problem for you public API.
