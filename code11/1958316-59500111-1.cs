ListBoxItem item1 = new ListBoxItem();
item1.Content = textBox.Text;
listBox.Items.Add(item1);
// Do the same with item2, item 3,... item n
Show in a Console Window:
foreach (var item in listBox.Items)
{
    Console.WriteLine(item);
}
