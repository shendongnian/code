       IEnumerable<int[]> GenerateRoll(int dies, int faces, int max_generations)
        {
            if (max_generations == 0)
                return Enumerable.Empty<int[]>();
            var allFaces = Enumerable.Range(1, faces).ToArray();
            var allOnes = Enumerable.Repeat(1, dies);
            var count = (int)Math.Pow(faces, dies);
            return
                Enumerable.Range(0, count)
                .Select(roll => ToBaseX(roll, faces, allFaces, allOnes.ToArray()))
                .SelectMany(roll =>                
                    roll
                    .Where(v => v == faces) //for each exploding roll
                    .SelectMany(_ =>
                            GenerateRoll(1, faces, max_generations - 1) //roll a single die
                            .Select(last => roll.Concat(last).ToArray()) //the new roll gets appended to the streak
                    )
                    .Prepend(roll)
                );
        }
