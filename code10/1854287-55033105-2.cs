    List<string> ids = new List<string> { "111", "222", "333" };
    var result = xml
        .Elements("Payment")
        .Where(p => {
            var invoiceIds = p.Elements("Invoice").Elements("Id").Select(o => o.Value);
            return ids.Intersect(invoiceIds).Any();
        }
    );
