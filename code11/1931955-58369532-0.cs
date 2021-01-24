string path = @"C:\Some\Text\File.txt";
List<string> outputValues = new List<string>
{
    "A Enr",
    "B Cds",
    "C Cdr",
    "D Der",
    "A Enr",
    "B Cds"
};
List<string> foundValues = new List<string>();
foreach (string outputValue in outputValues)
{
    if (foundValues.Contains(outputValue))
        continue; // Doesn't output this output value twice
    foundValues.Add(outputValue);
    using (StreamWriter sw = File.Exists(path) ? File.AppendText(path) : File.CreateText(path))
    {
        sw.WriteLine(outputValue);
    }
}
