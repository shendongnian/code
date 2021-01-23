Control[] array = new Control[100];
foreach (Control c in FormX.Controls)
{
    int index;
    if (c.Name.StartsWith("textbox") && int.TryParse(c.Name.Substring(7),out index))
    {
        array[index] = c;
    }
}
