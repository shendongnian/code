    static void Ajouter(List<Personne> maliste)
    {
        string s;
        bool stop = false;
        int i = 0;
        while(!stop)
        {
            Console.WriteLine("Entrez les informations ou entrez pour terminez!!");
            Console.WriteLine("Entrez le nom de la personne numero "+ (i+1));
            s = Console.ReadLine();
            if (s == "") break;
                var pers = new Personne();
                maliste.Add( pers );
                pers.nom = s;
                Console.WriteLine("Entrez le prenom de la personne numero " + (i + 1));
                s = Console.ReadLine();
            if (s == "") break;
                pers.prenom = s;
                Console.WriteLine("Entrez l'age de la personne numero " + (i + 1));
                s = Console.ReadLine();
            if (s == "") break;
                pers.age = int.Parse(s);
            i++;
       }
    }
