var linesToSkip = 10;
using(var fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read) )
{
    fileStream.Seek(lineLength * (linesToSkip - 1), SeekOrigin.Begin);
    using(var reader = new StreamReader(fileStream) )
    {
        var myNextLine = reader.ReadLine();
        // TODO: process the line
    }
}
2. If you don't know the line length, you have to read line by line and skip them until you get to the line number desired. The issue here is that is the line number is high, you will get a performance hit
var linesToSkip = 10;
using (var reader = new StreamReader(fileStream))
{
    for (int i = 1; i <= linesToSkip; ++i)
        reader.ReadLine();
    var myNextLine = reader.ReadLine();
    // TODO: process the line
}
And if you need just skip everything, you should do it without reading all the content into memory:
using(var fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read) )
{
    fileStream.Seek(0, SeekOrigin.End);
    
    // You can wait here for other processes to write into this file and then the ReadLine will provide you with that content
    using(var reader = new StreamReader(fileStream) )
    {
        var myNextLine = reader.ReadLine();
        // TODO: process the line
    }
}
