`
public void LogToFile(string text)
{
    string path = @"c:\temp\MyTest.txt";
    string appendText = text + Environment.NewLine;
    File.AppendAllText(path, appendText);
}
