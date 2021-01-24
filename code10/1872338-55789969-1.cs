         System.Text.StringBuilder gastring = new System.Text.StringBuilder();
    foreach (var line in OrderLines)
         {
             gastring.AppendLine("ga(\'ecommerce:addItem\', {");
                        gastring.AppendLine("id:\""+ line.OrderNumber  +"\",  // Order ID");
                        gastring.AppendLine("sku:\""+ line.SkuCode  +"\",                                     // SKU");
                        gastring.AppendLine("name:\""+ Microsoft.Security.Application.AntiXss.JavaScriptEncode(line.SkuName) + "\", ");
                        gastring.AppendLine("category:\""+  +"\" ,    // Category");
                        gastring.AppendLine("price:\""+ line.UnitPrice +"\",    // Price");
                        gastring.AppendLine("quantity:\" "+ line.Qty  +"\"   // Quantity");
                        gastring.AppendLine("});");
        }       
            <script type="text/javascript">
             gastring.ToString()
             ga('ecommerce:send');
            </script>
