C#
private static string GetChildValue(Panel panel, string name)
{
    var children = panel.Children;
    foreach (var child in children)
    {
        if (!(child is TextBox))
            continue;
        var textBox = (TextBox)child;
        if (textBox.Name.Equals(name))
            return textBox.Text;
    }
    return string.Empty;
}
private static void DoSomething()
{
    var stackPanel = new StackPanel();
    stackPanel.Children.Add(new TextBox { Name = "TextBox1", Text = "TextBox1 Value" });
    stackPanel.Children.Add(new TextBox { Name = "TextBox2", Text = "TextBox2 Value" });
    stackPanel.Children.Add(new TextBox { Name = "TextBox3", Text = "TextBox3 Value" });
    stackPanel.Children.Add(new TextBox { Name = "TextBox4", Text = "TextBox4 Value" });
    var textBox1Value = GetChildValue(stackPanel, "TextBox1");
}
