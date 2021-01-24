    CompositeCollection compositeCollection = new CompositeCollection();
    CollectionContainer cc1 = new CollectionContainer();
    cc1.Collection = AllSalesProfitList;
    CollectionContainer cc2 = new CollectionContainer();
    cc2.Collection = AllSalesReturnProfitList;
    
    compositeCollection.Add(cc1);
    compositeCollection.Add(cc2);
    
    ListSalesReportView.ItemsSource = compositeCollection;
