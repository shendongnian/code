`
if (!File.Exists(_filePath))
{
// close fileStream
    File.Create(_filePath).Close();
}
using (var streamWriter = File.AppendText(_filePath))
{
    //Write to file
}
`
