        public object GetMaxReportNo(string OfficeStationCombination = "")
		{
			    InspectionReport InspectionReport = new InspectionReport();
				string VelosiReportNo = "";
				var query = uow.InspectionReportRepository.GetQueryable().AsQueryable();
				if (query.Any())
				{
					var queryResult = query.Where(x => x.VelosiReportNo.Contains(OfficeStationCombination))
					                      .OrderByDescending(x => x.InspectionReportID)
										  .FirstOrDefault();
			    	if (queryResult != null)
				    	VelosiReportNo = queryResult.VelosiReportNo;
				}
				return VelosiReportNo;
		}
