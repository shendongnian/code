    void BulkInsert(GpsReceiverTrack[] gpsReceiverTracks)
    {
    	if (gpsReceiverTracks == null)
    	{
    		throw new ArgumentNullException(nameof(gpsReceiverTracks));
    	}
    
    	DataTable dataTable = new DataTable("GpsReceiverTracks");
    	dataTable.Columns.Add("ID", typeof(int));
    	dataTable.Columns.Add("DownloadedTrackID", typeof(int));
    	dataTable.Columns.Add("Time", typeof(TimeSpan));
    	dataTable.Columns.Add("Latitude", typeof(double));
    	dataTable.Columns.Add("Longitude", typeof(double));
    	dataTable.Columns.Add("Altitude", typeof(double));
    
    	for (int i = 0; i < gpsReceiverTracks.Length; i++)
    	{
    		dataTable.Rows.Add
    		(
    			new object[]
    			{
    					gpsReceiverTracks[i].ID,
    					gpsReceiverTracks[i].DownloadedTrackID,
    					gpsReceiverTracks[i].Time,
    					gpsReceiverTracks[i].Latitude,
    					gpsReceiverTracks[i].Longitude,
    					gpsReceiverTracks[i].Altitude
    			}
    		);
    	}
    
    	string connectionString = (new TeamTrackerEntities()).Database.Connection.ConnectionString;
    	using (var connection = new SqlConnection(connectionString))
    	{
    		connection.Open();
    		using (var transaction = connection.BeginTransaction())
    		{
    			using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
    			{
    				sqlBulkCopy.DestinationTableName = dataTable.TableName;
    				foreach (DataColumn column in dataTable.Columns)
    				{
    					sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
    				}
    
    				sqlBulkCopy.WriteToServer(dataTable);
    			}
    			transaction.Commit();
    		}
    	}
    
    	return;
    }
