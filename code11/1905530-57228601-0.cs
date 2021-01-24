ForEach (Control tb in gb.Controls)
{
  if tb is TextBox
    {
     int i;
     if (int.TryParse(tb.Text, out i))
     {
      if (i >= 0 && i <= 100)
      return;
     }
    }
    MessageBox.Show("Please enter a number from 1 - 100");
}
