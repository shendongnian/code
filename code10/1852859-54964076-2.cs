        const string priceblock_ourprice = "//*[@id=\"priceblock_ourprice\"]";
        const string priceblock_dealprice = "//*[@id=\"priceblock_dealprice\"]";  
        const string j_sku_discount_price = "//*[@id=\"j-sku-discount-price\"]";  
        const string j_sku_price = "//*[@id=\"j-sku-price\"]";  
        public void YourPrimaryFunction  
        {  
            decimal price;  
            switch (now.site)  
            {  
                case item.SITE.AMAZON:  
                    fetched = FetchPrice(priceblock_ourprice, priceblock_dealprice, out price);  
                    break;  
                    case item.SITE.ALI:  
                    fetched = FetchPrice(j_sku_discount_price, j_sku_price, out price);  
                    break;  
            }  
        }  
        private void FetchPrice(string xPathPrim, string xPathFallBack, decimal out price)  
        {  
            try  
                {  
                    price = driver.FindElement(By.XPath(xPathPrim)).Text;  
                    return true;  
                }  
                catch  
                {  
                    try  
                    {  
                        price = driver.FindElement(By.XPath(xPathFallBack)).Text;  
                        return true;  
                    }  
                    catch  
                    {  
                        return false;  
                    }  
                }  
        }
