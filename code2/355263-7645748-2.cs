            // Transform into transition points
            var inputWithBeforeAfter = input.SelectMany(
                dateRange => new[]
                    {
                        new TransitionWithCounts { DateTime = dateRange.From, Starts = 1 },
                        new TransitionWithCounts { DateTime = dateRange.To, Finishes = 1 }
                    });
