    public static void Main()
    {
        var inputs = new[]
        {
            "MA~CT~DE~NJ~NJ~~~~~~VEG-1825~AX7547~117824~NEG-1012~BEG-1011~~",
            "CT~DC~DE~MA~MD~NY~RI~VA~WA~WV~"
        };
    
    
        foreach(var input in inputs)
        {
            var plates = GetPlates(input);
            Console.Out.WriteLine("Input string: " + input);
            foreach(var plate in plates)
            {
                Console.Out.WriteLine(string.Format("{0} : {1}", plate.Key, plate.Value));
            }
        }
    }
    static KeyValuePair<string, string>[] GetPlates(string input)
    {
        var tokens = input.Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
        var states = tokens.Where(t => t.Length == 2).ToArray();
        var plates = tokens.Where(t => t.Length != 2)
                           .Select(s => s.Replace("-", string.Empty));
        return states.Zip(plates.Concat(Enumerable.Repeat<string>(null, states.Length)),
              (state, plate) => new KeyValuePair<string, string>(state, plate)).ToArray();
    }
