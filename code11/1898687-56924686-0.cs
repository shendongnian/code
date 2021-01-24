`
private void TextBox1_KeyUp(object sender, KeyEventArgs e)
{
    int index = listBox1.SelectedIndex;
    if(e.KeyCode == Keys.Up)
    {
         index--;
    }
    else if(e.KeyCode == Keys.Down)
    {
         index++;
    }
    listBox1.SelectedIndex = index;
}
`
