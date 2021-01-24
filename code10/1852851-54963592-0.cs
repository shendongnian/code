    private static Dictionary<string, string[]> pricePaths = new Dictionary<string, string[]> {
       [item.SITE.AMAZON] = new string[] { ""//*[@id=\"priceblock_ourprice\"]"",
                                           ""//*[@id=\"priceblock_dealprice\"]"" },
       [item.SITE.ALI] = new string[] { "//*[@id=\"j-sku-discount-price\"]",
                                        "//*[@id=\"j-sku-price\"]" },
    };
