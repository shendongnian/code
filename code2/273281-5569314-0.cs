    string[] split = Textbox1.Text.Split(Convert.ToChar("+"));
    int total = 0;
    foreach (string str in split)
    {
        int tempInt = 0;
        if (int.TryParse(str, out tempInt))
           total += tempInt;
    }
    System.Diagnostics.Debug.Write(total);
