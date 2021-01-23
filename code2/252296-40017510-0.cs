    foreach (Pet pet in v.Pets)
    {
        if (pet == null)
        {
            Console.WriteLine(" No pet");// enumerator is empty
            break;
        }
        Console.WriteLine("  {0}", pet.Name);
    }
