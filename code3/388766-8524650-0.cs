    var idd = session.CreateQuery("from ItemDeliveryDetail idd " + 
                              "join fetch idd.ItemDelivery " +
                              "left join fetch idd.SupplierInvoice " +
                              "where idd.Id = 21931828")
                 .Future<ItemDeliveryDetail>();
    var spc = session.CreateQuery("from ItemDeliveryDetail idd " + 
                              "join fetch idd.ItemDelivery id " +
                              "join fetch id.SpecialCondition spc " +
                             "where idd.Id = 21931828")
                 .Future<ItemDeliveryDetail>();
    var result = idd.ToList();
