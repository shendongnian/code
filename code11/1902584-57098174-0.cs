       class Program
        {
            static void Main(string[] args)
            {
                List<Goods> repoGoods = new List<Goods>();
                List<Unit> repoGoodsUnit = new List<Unit>();
                var results = (from m in repoGoods.Where(x =>
                     x.Date < DbFunctions.AddDays(DateTime.Now, 1))
                               join n in repoGoodsUnit on m.MasterID equals n.Id
                               select new DailyVM()
                               {
                                   GoodsName = n.GoodsName,
                                   Price = n.Price * m.Count,
                                   GoodsCount = m.Count,
                                   SheetNO = m.SheetNO,
                                   subtotal = n.Price * m.Count,
                                   Date = m.Date,
                                   MasterID = m.MasterID,
                               })
                 .GroupBy(x => new { name = x.GoodsName, sheet = x.SheetNO, date = x.Date, masterId = x.MasterID })
                 .Select(x => new DailyVM()
                 {
                     GoodsName = x.Key.name,
                     Price = x.Sum(y => y.Price),
                     GoodsCount = x.Sum(y => y.GoodsCount),
                     SheetNO = x.Key.sheet,
                     subtotal = x.Sum(y => y.subtotal),
                     Date = x.Key.date,
                     MasterID = x.Key.masterId
                 }).ToList();
            }
     
        }
        public class DailyVM
        {
            public string GoodsName { get; set; }
            public int Price { get; set; }
            public int GoodsCount { get; set; }
            public int SheetNO { get; set; }
            public int subtotal { get; set; }
            public DateTime Date { get; set; }
            public int MasterID { get; set; }
        }
        public class Goods
        {
            public DateTime Date { get; set; }
            public int MasterID { get; set; }
            public int Count { get; set; }
            public int SheetNO { get; set; }
            public string Stat { get; set; }
        }
        public class Unit
        {
            public int Id { get; set; }
            public string GoodsName { get; set; }
            public int Price { get; set; }
        }
        public static class DbFunctions
        {
            public static DateTime AddDays(DateTime time, int days)
            {
                return DateTime.Now;
            }
        }
