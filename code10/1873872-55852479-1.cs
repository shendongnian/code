foreach (Bike bike in Bikes)
{
    richTextBox1.Text = bk.Type;
    richTextBox1.Text = bk.SecurityCode.ToString();
    richTextBox1.Text = bk.Make;
    richTextBox1.Text = bk.Model;
    richTextBox1.Text = bk.Year.ToString();
    richTextBox1.Text = bk.WheelSize;
    richTextBox1.Text = bk.Forks;
}
