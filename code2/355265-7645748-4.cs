            // Iterate manually since we want to keep a current count
            // and emit stuff
            var output = new List<DateTime>();
            var state = 0;
            TransitionWithCounts prev = null;
            foreach (var current in deduped)
            {
                // Coming to a new transition point
                // If we are ON, we need to emit a new midpoint
                if (state > 0)
                {
                    // Emit new midpoint between prev and current
                    output.Add(prev.DateTime.AddTicks((current.DateTime - prev.DateTime).Ticks / 2));
                }
            
                // Update state
                state -= current.Finishes;
                state += current.Starts;
                prev = current;
            }
