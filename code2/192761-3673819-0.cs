    do
    {
        Console.WriteLine("EnterNextCommand");
        inputstring = Console.ReadLine();
        response = Convert.ToChar(inputstring);
        switch (response)
        {
            case 'A':
            case 'a':
            //case A logic
            break;
            case 'B':
            case 'b':
            //case B logic
            break;
            //etc.
            default:
            //they enter something you're not handling
            break;
        }
    }
    while (inputstring != "Z")
