    static void Main(string[] args)
    {
        var species = "Lycopodiophyta";
        var uri = new Uri($"http://api.gbif.org/v1/species/match?&name={ species }");
        
        // callable method to display the values. like your foreach loop
        // it will be passed to the async method, who will then call it instead.
        Action<Animal> populateLabel = (Animal animal) =>
        {
            Console.WriteLine($"- {animal.kingdom}");
            Console.WriteLine($"- {animal.phylum}");
            Console.WriteLine($"- {animal.rank}");
        };
        // I need to use new Program(), but you dont need to do that
        new Program().AsyncToConsole(uri, populateLabel );
        Console.ReadLine();
        return;
    }
