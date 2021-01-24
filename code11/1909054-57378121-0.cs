    var ordered = cities
                    .Select(city => new { Name = city, NameForOrdering = string.Join(string.Empty, city.Where(c => Char.IsLetterOrDigit(c)).ToArray()) })
                    
                    .OrderBy(city => city.NameForOrdering)
                    .Select(city => city.Name)
                    .ToList();
