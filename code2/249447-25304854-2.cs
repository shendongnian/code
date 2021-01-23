    public class FileParser
    {
        private readonly TextReader _textReader;
      
        public FileParser(TextReader reader)
        {
            _textReader = reader;
        }
        public List<TradeInfo> ProcessFile()
        {
            var rows = _textReader.ReadLine().Split(new[] { ',' }).Take(4);
            return FeedMapper(rows.ToList());
        }
        private List<TradeInfo> FeedMapper(List<String> rows)
        {
            var row = rows.Take(4).ToList();
            var trades = new List<TradeInfo>();
            trades.Add(new TradeInfo { TradeId = row[0], FutureValue = Convert.ToInt32(row[1]), NotionalValue = Convert.ToInt32(row[3]), PresentValue = Convert.ToInt32(row[2]) });
            return trades;
        } 
    }
