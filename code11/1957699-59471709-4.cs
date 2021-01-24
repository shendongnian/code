    decimal US_Dollars = 1.296m;
    
    Console.WriteLine("$" + string.Format("{0:0.00}", (decimal)24.50 * US_Dollars));
    // output: $31.75
In your code, you will use the following
    if (cmbcurrency.Text == "USD")
    {
        txtresult.Text = System.Convert.ToString("$" + string.Format("{0:0.00}", British_Pound * US_Dollars));
    }
**Recommendation:** Use a web api to pull the rate instead of hardcoding the number for conversion. [This is one example:][1]
This code is to use the API to get the correct conversion rate
    public static double GetRate(string baseFormat, string resultFormat)
    {
        RestClient client = new RestClient($"https://api.exchangeratesapi.io/latest?base={baseFormat}"); // CHange the base to whichever you are converting
        RestRequest request = new RestRequest(Method.GET);
        request.AddHeader("Accept", "*/*");
        var response = client.Execute(request);
        var rates = JObject.Parse(response.Content)["rates"];
        return double.Parse(rates[resultFormat].ToString());
    }
    //Usage
    double US_Dollars = GetRate("GBP", "USD");
    Console.WriteLine("$" + string.Format("{0:0.00}", (double)24.50 * US_Dollars));
// output: $31.74
  [1]: https://api.exchangeratesapi.io/latest?base=GBP
