    private static string RemoveNoise(string input)
    {
        input = Regex.Replace(input, @"\r\n?|\n", string.Empty); // no more NewLine stuff
        return input.Replace(" ", string.Empty)
            .Replace(@"""",string.Empty); 
    }
    ...
	public class PriceData
	{
		public string UUID { get; set; }
		public string Updated { get; set; }
		public string Price { get; set; }
		public string FoilUpd { get; set; }
		public string FoilPrc { get; set; }
	}
    ...
    string sPaperTag = @"PAPER:{";
    string sPprFlTag = @"PAPERFOIL:{";
    ...
	dynamic prices = JsonConvert.DeserializeObject(sJSON);
	IDictionary<string, JToken> pricelist = prices;
	foreach (var priceline in pricelist)
	{
		PriceData pData = new PriceData();
		pData.UUID = priceline.Key.ToString();
		bool bWeHavePrice = false;
		string pi = RemoveNoise(priceline.Value.ToString().ToUpper());
		// parse out paper, paperFoil dates & prices manually (unusual JSON format...)
		iBeg = pi.IndexOf(sPaperTag);
		if (iBeg >= 0)
		{
			sTemp = pi.Substring(iBeg, pi.Length - iBeg);
			iBeg = sTemp.IndexOf(":") + 2;
			iEnd = sTemp.IndexOf("}");
			sTemp = sTemp.Substring(iBeg, iEnd - iBeg); // either YYYY-MM-DD:n.nn, or an empty string
			iBeg = sTemp.IndexOf(":");
			if (iBeg > 0)
			{
				if (DateTime.TryParse(sTemp.Substring(0, iBeg), out dtTemp)) { pData.Updated = dtTemp.ToString(); bWeHavePrice = true; }
				if (Decimal.TryParse(sTemp.Substring(++iBeg, sTemp.Length - iBeg), out decTemp)) { pData.Price = decTemp.ToString(); bWeHavePrice = true; }
			}
		}
