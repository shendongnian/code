            // Build a list of distinct colours
            var allColours = input.SelectMany(x => x.Select(y => y)).Distinct();
            foreach (var colour in allColours)
            {
                // Find all colours linked to this one
                var linkedColours = input.Where(x => x.Contains(colour)).SelectMany(x => x.Select(y => y)).Distinct().ToList();
                // See if any of these colours are already in the results
                var linkedResult = results.FirstOrDefault(x => x.Any(y => linkedColours.Contains(y)));
                if (linkedResult == null)
                {
                    // Create a new result
                    results.Add(linkedColours);
                }
                else
                {
                    // Add missing colours to the result
                    linkedResult.AddRange(linkedColours.Where(x => !linkedResult.Contains(x)));
                }
            }
