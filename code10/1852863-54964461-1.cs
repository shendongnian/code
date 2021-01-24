	private static Dictionary<string, string[]> __pricePaths = new Dictionary<string, string[]>
	{
		{ item.SITE.AMAZON, new [] { "//*[@id=\"priceblock_ourprice\"]", "//*[@id=\"priceblock_dealprice\"]" } },
		{ item.SITE.ALI, new [] { "//*[@id=\"j-sku-discount-price\"]", "//*[@id=\"j-sku-price\"]" } },
	};
