    string Str = textBox1.Text.Trim();
    double Num;
    bool isNum = double.TryParse(Str, out Num);
    if (isNum)
        MessageBox.Show(Num.ToString());
    else
        MessageBox.Show("Invalid number");
