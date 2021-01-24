            var yellow = 0;
            var pink = 1;
            var red = 2;
            var white = 3;
            var blue = 4;
            var input = new List<List<int>> {
                new List<int> { pink, yellow },
                new List<int> { yellow, pink, red},
                new List<int> { red, yellow},
                new List<int> { white, blue},
                new List<int> { blue, white}
                };
            var output = new List<List<int>>();
            // Start with the longest lists
            foreach (var item in input.OrderByDescending(x => x.Count))
            {
                // See if it will fit in an existing output value
                var itemIsEntirelyContainedByExistingOutput = false;
                foreach (var outputValue in output)
                {
                    if (item.All(colour => outputValue.Contains(colour)))
                    {
                        itemIsEntirelyContainedByExistingOutput = true;
                        break;
                    }
                }
                // No, so add this to the list of outputs
                if (!itemIsEntirelyContainedByExistingOutput)
                {
                    output.Add(item);
                }
            }
