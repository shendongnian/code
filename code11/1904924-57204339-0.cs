	// get PropertyName from ReportPropertyEntity, and find it on TicketReportPropertyEntity
	var myScreen = new MyScreenClass()
	{
		TicketReportPropertyEntities = new List<UserQuery.TicketReportPropertyEntity>
		{
			new TicketReportPropertyEntity{
				Amount=1.0m,
				ReportProperty = new ReportPropertyEntity{PropertyName="Name"}
			}
		}
	};
	var reportPropertyAccessor = typeof(TicketReportPropertyEntity).GetProperty(nameof(TicketReportPropertyEntity.ReportProperty));
	var propertyNameAccessor = typeof(ReportPropertyEntity).GetProperty(nameof(ReportPropertyEntity.PropertyName));
	var amountAccessor = typeof(TicketReportPropertyEntity).GetProperty(nameof(TicketReportPropertyEntity.Amount));
	typeof(TicketReportPropertyEntity).GetProperties().Dump();
	
	foreach(object ticketReportEntity in myScreen.TicketReportPropertyEntities){
		var ticketReportPropertyEntity=reportPropertyAccessor.GetValue(ticketReportEntity);
		var pn = propertyNameAccessor.GetValue(ticketReportPropertyEntity);
		if("Name" == (string)pn){
			ticketReportPropertyEntity.Dump();
			amountAccessor.SetValue(ticketReportEntity,2.0m);
		}
	}
