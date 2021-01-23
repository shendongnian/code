            double[] probabilities = new double[] { 0.3, 0.4, 0.3};
            probabilities
                .Aggregate(
                    new {sum=Enumerable.Empty<double>(), last = 0.0d},
                    (a, c) => new {
                        sum = a.sum.Concat(Enumerable.Repeat(a.last+c,1)),
                        last = a.last + c
                    },
                    a => a.sum
                );
