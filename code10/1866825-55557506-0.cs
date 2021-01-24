    static void Translate(ref string dna)
    {
        var map = new string[] {"AGTC", "TCAG"};
        dna = string.Join("", dna.Select(c => map[1][map[0].IndexOf(c)]).Reverse());
    }
