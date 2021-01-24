    static ConcurrentDictionary<string, decimal> cachedDownloads =
           new ConcurrentDictionary<string, decimal>();
    
            public async Task<decimal> CurrencyConversionAsync(decimal amount, string fromCurrency, string toCurrency)
            {
                string content = "";
                string url = string.Format(urlPattern, fromCurrency, toCurrency);
                Decimal result = 0;
                 decimal exchangeRate = 0;
                if (CheckForInternetConnection() == false)
                {
                    result = amount * decimal.Parse("1.11");
                   return result;
                }
    
                if (cachedDownloads.TryGetValue(content, out exchangeRate))
                {
                        result = (amount * exchangeRate);
                        return result;
           
                }
