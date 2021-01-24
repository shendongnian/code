    var listStagiaire = new List<Stagiaire>();
    int i;
    for (i = 0; i < notes.Length; i++)
    {
        Console.WriteLine("Veuillez saisir la note" + i+"\n");
        var stg = new Stagiaire(compteur++, "karami", "loubna", "TDI", new[]
        {
            double.Parse(Console.ReadLine()),
            double.Parse(Console.ReadLine()),
            double.Parse(Console.ReadLine())
        });
        listStagiaire.Add(stg);
    }
