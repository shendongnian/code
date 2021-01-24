    IEnumerable<(int gen, int value)[]> GenerateRoll(int dies, int faces, int max_generations, int gen = 1)
    {
        if (max_generations == gen)
            return Enumerable.Empty<(int, int)[]>();
        var allFaces = Enumerable.Range(1, faces).ToArray();
        var allOnes = Enumerable.Repeat(1, dies);
        return
             Enumerable.Range(0, (int)Math.Pow(faces, dies))
            .Select(roll => ToBaseX(roll, faces, allFaces, allOnes.ToArray()))
            .Select(roll => roll.Select(value => (gen, value)).ToArray())
            .SelectMany(roll =>
            {
                var explosions = roll.Count(r => r.value == faces);
                if (explosions == 0)
                    return new[] { roll };
                return GenerateRoll(explosions, faces, max_generations, gen + 1) //roll explosion dies
                       .Select(last => roll.Concat(last).ToArray()); //the new roll gets appended to the streak
            });
    }
