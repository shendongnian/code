var tab = new StringBuilder();
int lineCount = 0;
string textheader = "Vendor\tDate\tInvoice\tPO\tTax\tTotal\tAcount\tType\tJobs\tClass" + Environment.NewLine;
if (File.Exists(textcsvpath)) {
    FileStream fs = File.OpenRead(textcsvpath);
    string[] fileContent = File.ReadAllLines(textcsvpath);
    lineCount = fileContent.Length - 1; // assume the first line is the header
}
foreach (var line in textlinestoadd)
{
    tab.AppendLine(line.ToString());
    lineCount++;
    if (lineCount > 0 && lineCount % 500 == 0)
    {
        if (!File.Exists(textcsvpath))
        {
            File.WriteAllText(textcsvpath, textheader);
        }
        File.AppendAllText(textcsvpath, tab.ToString());
        tab.Clear();
        textcsvpath = "some-new-file-name";
    }
}
if (!File.Exists(textcsvpath))
{
    File.WriteAllText(textcsvpath, textheader);
}
File.AppendAllText(textcsvpath, tab.ToString());
You'll need to do something to determine the new file name as you add a new file.
