            var items = new[] {
               new { Id=2, Priority=3 },
               new { Id=2, Priority=5 },
               new { Id=1, Priority=4 },
               new { Id=4, Priority=4 },
               new { Id=4, Priority=4 }
            };
            var deduped = items
                .GroupBy(item => item.Id)
                .Select(group => group.OrderByDescending(item => item.Priority).First())
                .OrderBy(item => item.Id);
