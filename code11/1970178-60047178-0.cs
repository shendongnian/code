    foreach(var result in results) {
                if(result.Stops != null) 
                    foreach(var stop in result.Stops) {
                        stop.EarliestArrival = DateTime.SpecifyKind((DateTime)stop.EarliestArrival, DateTimeKind.Utc);
                        stop.LatestArrival = DateTime.SpecifyKind((DateTime)stop.LatestArrival, DateTimeKind.Utc);
                    }
            }
