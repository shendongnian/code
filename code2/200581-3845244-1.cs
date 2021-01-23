    var sequences = input.Distinct()
                         .GroupBy(num => Enumerable.Range(num, 1 + input.Max() - num)
                                                   .TakeWhile(input.Contains)
                                                   .Last())
                         .Where(seq => seq.Count() >= 3)
                         .Select(seq => seq.OrderBy(num => num)); // not necessary unless ordering is desirable inside each sequence.
