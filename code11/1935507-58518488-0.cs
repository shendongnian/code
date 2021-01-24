 c#
private void listBox2_MouseClick(object sender, MouseEventArgs e)
{
    var list = RSSreader.rssRead(tbxURL.Text);
    foreach (Tuple<string, string> item in list)
    {
        if (item != listBox2.SelectedItem)
        {
            richTextBox1.Text = item.Item2.ToString();
        }
    }
}
You run through all the items saying: "If this is not the droid I'm looking for, I will add it to the RichTextBox". I think what you mean is: "If this IS the droid I'm looking for, I will add it to the RichTextBox.
That would be:
 c#
private void listBox2_MouseClick(object sender, MouseEventArgs e)
{
    var list = RSSreader.rssRead(tbxURL.Text);
    foreach (Tuple<string, string> item in list)
    {
        if (item == listBox2.SelectedItem) // Notice the equality operator
        {
            richTextBox1.Text = item.Item2.ToString();
        }
    }
}
I don't know if it's a typo on your part, but the equality operator is `==`, not `!=`.
Your code would always show the last item in the list.
