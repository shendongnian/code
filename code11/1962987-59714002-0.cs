csharp
[MenuItem("Tools/Read file")]
public void readTextFileLines(string fileName, string Step)
{
    foreach (string line in System.IO.File.ReadAllLines("Assets/Resources/" + fileName + ".txt))
    {
        if (line.Contains(Step))
        {
            string[] separator = { "-" };
            string[] strList = line.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
            infoText.text = string.Join("\n", strList.Skip(1));
        }
    }
}
