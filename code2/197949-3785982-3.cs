    int i = 0;
    foreach (Control c in FormX.Controls)
    {
        int i2;
        if (c.Name.StartsWith("textbox") && int.TryParse(c.Name.Substring(7),out i2))
        {
            array[i] = c;
            i++;
        }
    }
    array = array.OrderBy(a => Convert.ToInt32(a.Name.Substring(7))).ToArray();
