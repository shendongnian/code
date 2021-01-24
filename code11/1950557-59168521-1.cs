    public async decimal CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
    {
        string url = string.Format(urlPattern, fromCurrency, toCurrency);
        var wc = new WebClient();
        var json = await wc.DownloadStringAsync(url);
        Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);
        decimal exchangeRate = (decimal)token.SelectToken("rate");
        var result = (amount * exchangeRate);
        return result;
    }
