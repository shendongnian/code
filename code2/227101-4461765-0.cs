    string str = "";
    do
    {
        str = Console.ReadLine();
        if(!string.IsNullOrEmpty(str))
            Console.WriteLine("\t\"{0}\"", Convert.ToDouble(str));
    }
    while (str != "");
