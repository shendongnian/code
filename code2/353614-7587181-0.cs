    public string GetName()
    {
        String name = String.Null;
        do
        {
            Console.Write("Please Enter Correct Name: ");
            name = Console.ReadLine();
        } while (!ValidateName(name))
    }
    public bool ValidateName(string name)
    {
        //String validation routine
    }
