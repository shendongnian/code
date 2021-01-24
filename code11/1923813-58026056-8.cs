                //tick is 100ns
                const long TICKS_PER_15_MINUTES = 15 * 60 * 10000000L; //minutes, seconds, ticks 
                DateTime minTime = dates.OrderBy(x => x.Time).First().Time;
                List<Dates> results = dates.GroupBy(x => ((x.Time.Ticks - minTime.Ticks) % TICKS_PER_15_MINUTES) < (TICKS_PER_15_MINUTES / 2)
                    ? TICKS_PER_15_MINUTES * ((x.Time.Ticks - minTime.Ticks) / TICKS_PER_15_MINUTES)
                    : (TICKS_PER_15_MINUTES * ((x.Time.Ticks - minTime.Ticks) / TICKS_PER_15_MINUTES)) + TICKS_PER_15_MINUTES)
                    .Select(x => x.OrderBy(y => Math.Abs( x.Key - y.Time.Ticks)).First())
                    .ToList();
