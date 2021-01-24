    for(int i = 0; i < ocean.Length; i++)
    {
        if (ocean[i] == "Nemo")
        {
            Console.WriteLine("We found Nemo on position {0}!", i);
            return;
        }
    }
    Console.WriteLine("He was not here");
