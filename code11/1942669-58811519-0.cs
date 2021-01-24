private void btnSmallest_Click(object sender, EventArgs e)
{
   var stringPrices = new List<string>();
   stringPrices.Add(comboBox1.Text);
   stringPrices.Add(comboBox2.Text);
   //TODO add error handling
   decimal[] prices = Array.ConvertAll(stringPrices, decimal.Parse);
 
   lblSmallest.Text = aAnalyzer.FindSmallestPriceChange(decimal).ToString();
}
(...)
public decimal FindSmallestPriceChange(IEnumerable<decimal> prices)
{
    ...
}
