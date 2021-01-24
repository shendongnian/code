    public class StockInfoViewModel
    {
        public StockInfoViewModel()
        {
            Stocks = new List<Stock>();
            string file ="../StockApp/App_Data/companylist.csv";
            using(var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Stocks.Add(new Stock { Name = values[1], Symbol = values[0] });
                }
            }
        }
        public List<Stock> Stocks { get; set; }
    }
    }
