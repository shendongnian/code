    int i;
    if (int.TryParse(TextBox1.Text, out i))
    {
        string odd = od.OddNumbers(i).ToString();
    }
    else
    {
        MessageBox.Show(TextBox1.Text + " is not a valid integer");
    }
