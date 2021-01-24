	public async Task<List<BrokerCommission>> FetchAsync(Broker broker)
	{
	  DateTime dateTime;
	  var comm = await _myContext.DocScan
		.Include(x => x.BrokerCommissionStatement)
		.Where(x => x.BrokerId == broker.BrokerId && x.Type == FileType.BrokerStatement
		&& x.BrokerCommissionStatement.PaymentYear == x.ScanDate.AddMonths(-1).Year
		&& x.BrokerCommissionStatement.PaymentMonth == x.ScanDate.AddMonths(-1).Month)
		.Select(x => new { x.FileGuid, x.FileUrl, x.ScanDate, commission = (x.BrokerCommissionStatement.Amount + x.BrokerCommissionStatement.Vat), commPaymentDay = (x.BrokerCommissionStatement.PaymentYear + "-" + x.BrokerCommissionStatement.PaymentMonth + "-" + x.BrokerCommissionStatement.PaymentDay) })
		.GroupBy(x => new { x.FileGuid, x.FileUrl, x.ScanDate, x.commPaymentDay })
		.Select(p => new BrokerCommission
		{
		  FileGuid = p.Key.FileGuid,
		  FileUrl = p.Key.FileUrl,
		  ScanDate = p.Key.ScanDate,
		  Commission = p.Sum(x => x.commission),
		  DateTime.TryParseExact(p.Key.commPaymentDay, "yyyy-MM-dd", out dateTime),
		  PaymentDay = dateTime
		})
		.OrderByDescending(x => x.ScanDate).Take(10)
		.ToListAsync();
	}
