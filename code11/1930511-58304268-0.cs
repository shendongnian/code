c#
public static void CopyStream(Stream input, Stream output)
{    
    byte[] buffer = new byte[16*1024];
    int read;
    while((read = input.Read (buffer, 0, buffer.Length)) > 0)
    {
        output.Write (buffer, 0, read);
    }
}
// Create MemoryStream
var ms = new MemoryStream();
CopyStream(streamFromDatabase, ms);
// Create PDF from MemoryStream
var pdf = PdfReader.Open(ms);
And now we can read the text from it like so:
c#
var sb = new StringBuilder();
foreach (var page in pdf.Pages)
{
     sb.Append(page.ExtractText());
}
