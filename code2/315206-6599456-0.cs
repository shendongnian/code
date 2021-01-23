    List<string> source = new List<string>();
    source.Add("Cat, Animal, 2");
    source.Add("Dog, Animal, 3");
    source.Add("Luke, Human, 1");
    source.Add("Owl, Animal, 0");
    List<string> dest = new List<string>(
        source
            .Select(s => s.Split(new []{',', ' '}, StringSplitOptions.RemoveEmptyEntries))
            .Select(s => { if(s[1] == "Animal") s[2] = (Convert.ToInt32(s[2]) + 1).ToString(); return s; })
            .Select(s => String.Join(", ", s))
        );
