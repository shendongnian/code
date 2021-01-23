    var inputDate = DateTime.Parse(txt_SendAt.Text);
    if (inputDate > DateTime.Now)
    {
        Console.WriteLine("DateTime entered is after now.");
    }
    else if (inputDate < DateTime.Now)
    {
        Console.WriteLine("DateTime entered is before now.");
    }
