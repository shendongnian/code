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
    // CHange the base to whichever you are converting
    RestClient client = new RestClient("https://api.exchangeratesapi.io/latest?base=GBP"); 
    RestRequest request = new RestRequest(Method.GET);
    request.AddHeader("Accept", "*/*");
    var response = client.Execute(request);
    var rateNeeded = JObject.Parse(response.Content)["rates"];
    double US_Dollars = double.Parse(rateNeeded["USD"].ToString());
    Console.WriteLine("$" + string.Format("{0:0.00}", (double)24.50 * US_Dollars));
// output: $31.74
  [1]: https://api.exchangeratesapi.io/latest?base=GBP
