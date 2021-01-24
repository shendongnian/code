            // Start with the longest lists
            foreach (var item in input.OrderByDescending(x => x.Count))
            {
                // See if it will fit in an existing output value
                if (!output.Any(x => item.All(x.Contains)))
                {
                    // No, so add this to the list of outputs
                    output.Add(item);
                }
            }
