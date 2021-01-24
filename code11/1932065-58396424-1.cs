var outputBuilder = new StringBuilder();
for (int i = 1; i < 100; i++)
{
    ComboBox box = (ComboBox)FindName("TEST" + i.ToString());
    outputBuilder.AppendLine(box.Text);
}
System.IO.File.WriteAllText(filename, outputBuilder.ToString());
