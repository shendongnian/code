    var TaxRates = MyOrder.Customers
                .SelectMany(customer => customer.SaleLines)
                .SelectMany(saleline => saleline.MerchTax.Concat(saleline.ShipTax))
                .GroupBy(tax => tax.Rate)
                .Select(tax => tax.First().Rate);
