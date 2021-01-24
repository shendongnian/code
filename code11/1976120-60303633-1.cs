public void button1_Click(object sender,EventArgs e)
{
    if (int.TryParse(textbox2.Text, out int value) && value >=0 && value <= 100)
    {
        progressbar.Value = value;
    }
    else progressbar.Value = 0;
}
In case you want to filter pressed keys consider to use `PreviewKeyDown` event like this.
 c#
public void textbox2_PreviewKeyDown(object sender,KeyEventArgs e)
{
    if ((e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) && e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
    {
        e.Handled = true;
    }
}
