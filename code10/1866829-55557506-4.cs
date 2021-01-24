    void Translate(ref string dna)
    {
        var map = new string[] {"AGTC", "TCAG"};
        var sb = new StringBuilder(dna.Length);
        for(int i = dna.Length-1; i > -1; i--)
        {
            sb.Append(map[1][map[0].IndexOf(dna[i])]);
        }
        dna = sb.ToString();
    }
