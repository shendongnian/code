    var months = data.Select(dict => {
                                string value;
                                bool hasValue = dict.TryGetValue("Month", out value);
                                return new { value, hasValue };
                             })
                     .Where(p => p.hasValue)
                     .Select(p => p.value)
                     .Distinct()
                     .ToList();
