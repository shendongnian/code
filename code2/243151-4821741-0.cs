    public List<Place> GetPlaces(SearchRequest request)
            {
                using (var c = new Context())
                {
                    var placereturn = c.Places.AsEnumerable();
                    if (request.StartTime.HasValue)
                        placereturn = c.Places.Where(s => s.Time.Any(t => t.StartTime >= request.StartTime));
                    if (request.EndTime.HasValue)
                        placereturn = c.Places.Where(s => s.Time.Any(t => t.EndTime >= request.EndTime));
                    if (request.DayOfWeek.HasValue)
                        placereturn = c.Places.Where(s => s.Time.Any(t => t.DayOfWeeks.Any(z => z.Name == request.DayOfWeek.Value)));
                    return placereturn;
                }
            }
