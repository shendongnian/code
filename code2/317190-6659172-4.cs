    protected string GetPayPalURL(string SERVER_URL, string business, string[] itemNames,
                int[] quantities, decimal[] amounts, double[] weight, string invoiceID, string transID, string NOTIFY_URL)
            {
                // Customer will be required to specify delivery address to PayPal - VERY IMPORTANT
                const string NO_SHIPPING = "2";
    
                StringBuilder url = new StringBuilder();
                url.Append(SERVER_URL + "?cmd=_cart&upload=1");
                url.Append("&business=" + HttpUtility.UrlEncode(business));
    
                for (int i = 0; i < itemNames.Length; i++)
                {
                    url.Append("&item_name" + "_" + (i + 1).ToString() + "=" + HttpUtility.UrlEncode(itemNames[i]));
                    url.Append("&quantity" + "_" + (i + 1).ToString() + "=" + quantities[i].ToString().Replace(",", "."));
                    url.Append("&amount" + "_" + (i + 1).ToString() + "=" + amounts[i].ToString().Replace(",", "."));
                    url.Append("&weight" + "_" + (i + 1).ToString() + "=" + weight[i].ToString().Replace(",", "."));
                }
    
                url.Append("&no_shipping=" + HttpUtility.UrlEncode(NO_SHIPPING));
                url.Append("&custom=" + HttpUtility.UrlEncode(invoiceID));
                url.Append("&txn_id=" + HttpUtility.UrlEncode(transID));
                url.Append("&notify_url=" + HttpUtility.UrlEncode(NOTIFY_URL));
    
                return url.ToString();
            }
