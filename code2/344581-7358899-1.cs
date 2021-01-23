    var closure = new RetrieveDataClosure(action, this);
    _csr = new CustomerServiceRepository();
    _csr.ServiceClient.GetChartDataCompleted += closure.ChartDataCompleted;
    _csr.ServiceClient.GetChartDataAsync( 
       Settings.Current.Customer.CustomerName, 
       pointId, 
       chartCollectionId); 
    _csr.ServiceClient.GetChartDataCompleted -= closure.ChartDataCompleted;
