private void btnSmallest_Click(object sender, EventArgs e)
{
   var stringPrices = new List<string>();
   stringPrices.Add(comboBox1.Text);
   stringPrices.Add(comboBox2.Text);
   //TODO add error handling
   decimal[] prices = Array.ConvertAll(stringPrices, decimal.Parse);
 
   lblSmallest.Text = aAnalyzer.FindSmallestPriceChange(prices).ToString();
}
(...)
public static decimal FindSmallestPriceChange(IEnumerable<decimal> prices)
{
    // There are many ways to do this. Here is one.
    var sorted = prices.ToList();
    sorted.Sort();
    if( prices.Count() < 2 ) return 0;
    decimal min = sorted[1] - sorted[0];
    for(int i = 2; i < sorted.Count() - 1 ; i++ ) {
        var diff = sorted[i-1] - sorted[i];
        if( diff < min ) min = diff;
    }
    return min;
}
# Test
Console.WriteLine(FindSmallestPriceChange(new []{66.6m}));
Console.WriteLine(FindSmallestPriceChange(new []{1m, 2m}));
Console.WriteLine(FindSmallestPriceChange(new []{1.1m, 4.4m, 2.2m}));
Console.WriteLine(FindSmallestPriceChange(new []{4.4m, -1.1m, 0m, 1.1m, 2.2m, }));
Output
0
1
1.1
-1.1
