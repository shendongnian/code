    string[] split = Textbox1.Text.Replace(" ","").Split(Convert.ToChar("+"));
    double total = 0;
    foreach (string str in split)
    {
        double tempInt = 0;
        if (double.TryParse(str, out tempInt))
           total += tempInt;
    }
    System.Diagnostics.Debug.Write(total);
