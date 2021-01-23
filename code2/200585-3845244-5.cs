    var sequences = input.Distinct()
                         .GroupBy(num => Enumerable.Range(num, int.MaxValue - num + 1)
                                                   .TakeWhile(input.Contains)
                                                   .Last())
                         .Where(seq => seq.Count() >= 3)
                         .Select(seq => seq.OrderBy(num => num)); // not necessary unless ordering is desirable inside each sequence.
