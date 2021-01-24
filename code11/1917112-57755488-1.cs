            public class Test
            {
                public static async Task<IEnumerable<DateLineGraphItem>> ExecuteQuery(IQueryable<IDatedEntity> entityList)
                {
                    return await entityList
                        .GroupBy(o =>new { o.MyDate.Date.Month, o.MyDate.Date.Year })
                        .Select(g => new DateLineGraphItem(){ Legend = new DateTime(g.Key.Year, g.Key.Month, 1), Number = g.Count() })
                        .ToListAsync();
                }
            }
        
            public class DateLineGraphItem
            {
                public DateTime Legend { get; set; }
                public int Number { get; set; }
            }
