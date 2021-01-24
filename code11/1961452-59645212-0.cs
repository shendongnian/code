     public List<Marque> lesMarques()
        {
            new string[] {
            "Beta",
            "Gas Gas",
            "Honda",
            "Husaberg",
            "Husqvarna",
            "Kawasaki",
            "KTM",
            "Sherco",
            "Suzuki",
            "TM",
            "Yamaha").Select(x => new Marque(x)).ToList();
        }
