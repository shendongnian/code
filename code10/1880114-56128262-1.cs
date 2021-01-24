    static Dictionary<string, Tech> cars = new Dictionary<string,Tech>();
    static void Main()
    {
        string[] auto = new string[]{"Lada Vesta"}; // <-- you also had a syntax error here
        Tech tech = new Tech()
            {
                Name = "Lada Vesta Sport",
                KM = 190
            };
        cars.Add(tech.Name, tech);        
        if (!cars.ContainsKey(auto[0]))  // <--- Use ContainsKey here
            cars.Add(auto[0], new Tech()
                {
                    Name = auto[0],
                    KM = 0
                });
    }
