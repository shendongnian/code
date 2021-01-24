    private void accessVendorGridData() {
      var vendors = _vendorservice
        .GetAllVendorAdd()  
        .GroupBy(item => item.Id)
        .ToDictionary(chunk => chunk.Key, chunk => chunk.ToList());
      var paymentTerms = _vendorservice
        .GetAllPaymentTerms()
        .GroupBy(item => item.Id)
        .ToDictionary(chunk => chunk.Key, chunk => chunk.SingleOrDefault());
      var allTaxSchemes = _vendorservice
        .GetAllTaxScheme()
        .GroupBy(item => item.Id)
        .ToDictionary(chunk => chunk.Key, chunk => chunk.SingleOrDefault());
      foreach (var item in getAllVendorList) {
        var Addr = vendors.TryGetValue(item.Id, out var addrs) 
           ? addrs 
           : new List<Vendor>();
        var paymentTerm = paymentTerms.TryGetValue(item.PaymentTermId, out var term) 
           ? term 
           : null;
        var taxscheme = allTaxSchemes.TryGetValue(item.PaymentTermId, out var scheme) 
           ? scheme 
           : null;
      } 
    }
