    do {
        try
        {
            Console.WriteLine("Enter your age");
            numAge = int.Parse(Console.ReadLine());
        }
        catch (FormatException err)
        {
            numAge = -1;
            Console.WriteLine(err.Messagec+ "Please try again");
        }
    } while (numAge < 0);
