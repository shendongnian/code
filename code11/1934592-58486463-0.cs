var joinedRecords = (from al in db.ApplicationLogs
					join cp in db.ClientPrograms on al.PrimaryKey equals cp.ClientProgramId into cp1
					select new 
						{Table = al.Table,
						PrimaryKey = al.PrimaryKey,
						SubTopicID = cp1.SubTopicID,
						IssueDetails = al.IssueDetails
						}
					).ToList();
This assumes you data source is `db`. The field SubTopicID in your results list will be `null` if there is no matching record in `ClientPrograms `
