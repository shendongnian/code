    class Trade {
        public DateTime CloseTime { get; set; }
        public decimal Profit { get; set; }
    }
    class TradeWithRunningProfit : Trade {
        public decimal RunningProfit { get; set; }
    }
    class Program {
        static IEnumerable<TradeWithRunningProfit> GetRunningProfits(IEnumerable<Trade> rows) {
            decimal running_profit = 0;
            return
                from row in rows
                select new TradeWithRunningProfit {
                    CloseTime = row.CloseTime,
                    Profit = row.Profit,
                    RunningProfit = (running_profit += row.Profit)
                };
        }
        static void Main(string[] args) {
            var rows = new[] {
                new Trade { CloseTime = new DateTime(11,10,09), Profit = 10},
                new Trade { CloseTime = new DateTime(11,10,10), Profit = 20},
                new Trade { CloseTime = new DateTime(11,10,11), Profit = 15},
            };
            foreach (var row_with_running_profit in GetRunningProfits(rows)) {
                Console.WriteLine(
                    "{0}\t{1}\t{2}",
                    row_with_running_profit.CloseTime,
                    row_with_running_profit.Profit,
                    row_with_running_profit.RunningProfit
                );
            }
        }
    }
